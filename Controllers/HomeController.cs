using System.Diagnostics;
using System.Net.Mail;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using backend.Models;
using System.IO.Pipelines;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
namespace backend.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    private readonly PostgresContext _dbcontext;
    private readonly IConfiguration _config;
    public HomeController(ILogger<HomeController> logger, PostgresContext context, IConfiguration config)
    {
        _logger = logger;
        _dbcontext = context;
        _config = config;
    }

    public IActionResult Index()
    {
        string UserEmail = HttpContext.Session.GetString("Email");
        if (UserEmail != null)
        {
            var existingUser = _dbcontext.Userlogins.Any(u => u.Email == UserEmail);
            if (existingUser)
            {
                return RedirectToAction("Content", "Main");
            }
        }
        if (Request.Cookies["Email"] != null)
        {
            return RedirectToAction("Content", "Main");
        }
        return View();
    }

    public IActionResult ForgotPassword(string email)
    {
        var vm = new userEmail(email);
        return View(vm);
    }
    [HttpGet]
    public IActionResult ResetPassword(string email)
    {
        return View(new ResetPasswordModel { Email = email });
    }
    [HttpPost]
    public IActionResult ResetPassword(ResetPasswordModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        if (model.NewPassword != model.ConfirmPassword)
        {
            ModelState.AddModelError("ConfirmPassword", "Passwords do not match");
            return View(model);
        }

        var user = _dbcontext.Userlogins.FirstOrDefault(u => u.Email == model.Email);
        if (user == null)
        {
            return RedirectToAction("Index","Home");
        }
        user.Password = encryptPassword(model.NewPassword);
        _dbcontext.SaveChanges();
        return RedirectToAction("Index","Home");
    }

    [HttpPost]
    public IActionResult Login(UserDemo model)
    {
        string userPassword = encryptPassword(model.Password);
    var existingUser = _dbcontext.Userlogins.FirstOrDefault(u => u.Email == model.Email &&  u.Password == userPassword);
    var userRole= _dbcontext.Userroles.FirstOrDefault(u=> u.Roleid == existingUser.Roleid);
    if (existingUser != null)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_config["Jwt:Key"]);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.Email, existingUser.Email),
                new Claim(ClaimTypes.Role, userRole.Rolename)
            }),
            Expires = DateTime.UtcNow.AddHours(1),
            Issuer = _config["Jwt:Issuer"],
            Audience = _config["Jwt:Audience"],
            SigningCredentials = new SigningCredentials(
                new SymmetricSecurityKey(key), 
                SecurityAlgorithms.HmacSha256Signature)
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);
        var tokenString = tokenHandler.WriteToken(token);

        HttpContext.Session.SetString("Token", tokenString);
        HttpContext.Session.SetString("Email", model.Email);
        HttpContext.Session.SetString("Role", userRole.Rolename);

        if (model.IsRemember)
        {
            CookieOptions cookie = new CookieOptions()
            {
                Expires = DateTime.Now.AddDays(30)
            };
            Response.Cookies.Append("Token", tokenString, cookie);
            Response.Cookies.Append("Email", model.Email, cookie);
            Response.Cookies.Append("Jwt", tokenString,cookie);
        }

        return RedirectToAction("Content", "Main");
    }

    ModelState.AddModelError(string.Empty, "Invalid login attempt");
    return RedirectToAction("Index", "Home");
    }

    [HttpPost]
    public IActionResult SendEmailLink(userEmail model)
    {
        string toemail = model.Email;
        SendEmail(toemail);
        return RedirectToAction("Index", "Home");
    }
    public void SendEmail(string toemail)
    {
        try
        {
string emailBody = $@"<a href='http://localhost:5150/Home/ResetPassword?email={WebUtility.UrlEncode(toemail)}'>Reset Password</a>";
            string smtpEmail = _config.GetValue<string>("SMTPCredentials:Email");
            string smtpappPass = _config.GetValue<string>("SMTPCredentials:AppPass");

            SmtpClient smtpclient = new SmtpClient("mail.etatvasoft.com")
            {
                Port = 587,
                Credentials = new NetworkCredential(smtpEmail, smtpappPass),
                EnableSsl = true,
            };

            MailMessage mail = new MailMessage
            {
                From = new MailAddress(smtpEmail),
                Subject = "Reset Password for PizzaShop",
                Body = emailBody,
                IsBodyHtml = true,

            };
            mail.IsBodyHtml = true;
            mail.To.Add(toemail);
            smtpclient.Send(mail);
            return;
        }
        catch (Exception ex)
        {
            throw (ex);
        }
    }
    public static string encryptPassword(string pass)
    {
        byte[] encode = new byte[pass.Length];
        encode = System.Text.Encoding.UTF8.GetBytes(pass);
        string encodedData = Convert.ToBase64String(encode);
        return encodedData;
    }
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

