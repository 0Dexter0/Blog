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
        public string GetUser()
        {
            var claim = HttpContext.User.Claims.FirstOrDefault(
                c => c.Type == ClaimTypes.Email && c.Value is not null);
            ///TODO: check claim
            if (claim is null)
            {
                
            }

            return claim.Value;
        }
    }
}