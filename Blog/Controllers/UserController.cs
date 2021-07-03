using System.Linq;
using System.Security.Claims;
using Blog.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Controllers
{
    [Authorize]
    [Route("user")]
    public class UserController : Controller
    {
        [HttpGet]
        public User GetUser()
        {
            var email = HttpContext.User.Claims.FirstOrDefault(
                c => c.Type == ClaimTypes.Email && c.Value is not null)?.Value;
            ///TODO: return user from db
            
            return new(){Email = email};
        }
    }
}