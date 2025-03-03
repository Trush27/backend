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
    public IActionResult Content(string searchTerm = "", int page = 1, int itemsPerPage = 5)
    {
        var result = Users(searchTerm, page, itemsPerPage);
        return View(result);
    }

    public IActionResult Users(string searchTerm = "", int page = 1, int itemsPerPage = 5)
    {
        var query = _dbcontext.Userdetails
            .Include(ud => ud.User)       
            .Include(ud => ud.Role)       
            .Where(ud => !ud.Isdeleted && !ud.User.Isdeleted);

        if (!string.IsNullOrEmpty(searchTerm))
        {
            searchTerm = searchTerm.ToLower();
            query = query.Where(ud =>
                ud.Firstname.ToLower().Contains(searchTerm) ||
                ud.Lastname.ToLower().Contains(searchTerm) ||
                ud.User.Email.ToLower().Contains(searchTerm) ||
                ud.Phonenumber.Contains(searchTerm)
            );
        }

        var totalItems = query.Count();
        var totalPages = (int)Math.Ceiling(totalItems / (double)itemsPerPage);
        
        var users = query
            .Skip((page - 1) * itemsPerPage)
            .Take(itemsPerPage)
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

        var model = new PaginatedViewModel<UserTable>
        {
            Items = users,
            CurrentPage = page,
            TotalPages = totalPages,
            TotalItems = totalItems,
            ItemsPerPage = itemsPerPage,
            SearchTerm = searchTerm
        };

        return View("Content", model);
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