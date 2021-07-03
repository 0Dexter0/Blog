using System.Linq;
using System.Security.Claims;
using Blog.Models;
using Blog.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Controllers
{
    [Route("user")]
    public class UserController : Controller
    {
        private UserRepository _userRepository = new();
        
        [Authorize]
        [HttpGet]
        public User GetUser()
        {
            var email = HttpContext.User.Claims.FirstOrDefault(
                c => c.Type == ClaimTypes.Email && c.Value is not "")?.Value;

            return _userRepository.GetUserByEmail(email);
        }

        [HttpGet]
        [Route("{id}")]
        public User GetUserById([FromRoute] long id)
        {
            User user = _userRepository.GetUserById(id);

            return user;
        }
    }
}