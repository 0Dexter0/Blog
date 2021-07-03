using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Blog.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Controllers
{
    [Route("home")]
    public class HomeController : Controller
    {
        private static List<User> _users = new();

        [Authorize]
        [HttpGet]
        public string HomeGet() => "home";

        [HttpGet]
        [Route("user")]
        public User GetUser()
        {
            var user = HttpContext.User;

            return null;
        }
    }
}