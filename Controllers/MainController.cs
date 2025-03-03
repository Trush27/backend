using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using backend.Models;
using System.IO.Pipelines;
using System.Net;
using static Microsoft.AspNetCore.Http.HttpContext;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
namespace backend.Controllers;
public class MainController : Controller
{
    private readonly ILogger<MainController> _logger;

    private readonly PostgresContext _dbcontext;
    public MainController(ILogger<MainController> logger, PostgresContext context)
    {
        _logger = logger;
        this._dbcontext = context;
    } 
     public IActionResult Content()
    {
        Users();
        return View();
    }
    public IActionResult Users()
{
    var users = _dbcontext.Userdetails
        .Include(ud => ud.User)       
        .Include(ud => ud.Role)       
        .Where(ud => !ud.Isdeleted && !ud.User.Isdeleted)  
        .Select(ud => new UserTable
        {
            UserId = ud.Userid,
            Name = $"{ud.Firstname} {ud.Lastname}",
            Email = ud.User.Email,
            Phone = ud.Phonenumber,
            Role = ud.Role.Rolename,
            Status = ud.Status ? "active" : "inactive",
            ProfileImage = ud.Profileimage 
        })
        .ToList();

    return View(users);
}
[Authorize(Roles = "Admin")]
public IActionResult Logout()
    {   
        HttpContext.Session.Clear();
        foreach (var cookie in Request.Cookies.Keys)
        {
            Response.Cookies.Delete(cookie);
        }
        return RedirectToAction("Index","Home");
    }
[HttpPost]
public IActionResult Delete(int id)
{
    try
    {
        using (var transaction = _dbcontext.Database.BeginTransaction())
        {
            // Get both user detail and login records
            var userDetail = _dbcontext.Userdetails.FirstOrDefault(u => u.Userid == id);
            var userLogin = _dbcontext.Userlogins.FirstOrDefault(u => u.Userid == id);

            if (userDetail != null && userLogin != null)
            {
                // Soft delete both records
                userDetail.Isdeleted = true;
                userLogin.Isdeleted = true;

                _dbcontext.SaveChanges();
                transaction.Commit();
                return Ok(new { success = true, message = "User deleted successfully" });
            }

            return NotFound(new { success = false, message = "User not found" });
        }
    }
    catch (Exception ex)
    {
        _logger.LogError(ex, "Error deleting user");
        return StatusCode(500, new { success = false, message = "Error deleting user" });
    }
}
}