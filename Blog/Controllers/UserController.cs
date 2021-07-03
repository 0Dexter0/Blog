using System.Linq;
using System.Security.Claims;
using Blog.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Controllers
{
    [Route("user")]
    public class UserController : Controller
    {
        [Authorize]
        [HttpGet]
        public User GetUser()
        {
            var email = HttpContext.User.Claims.FirstOrDefault(
                c => c.Type == ClaimTypes.Email && c.Value is not null)?.Value;
            ///TODO: return user from db
            
            return null;
        }

        [HttpGet]
        [Route("{id}")]
        public User GetUserById([FromRoute] long id)
        {
            /// TODO: return user from db 

            return null;
        }
    }
}