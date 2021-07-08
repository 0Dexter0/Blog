using System.Linq;
using System.Security.Claims;
using Blog.Components.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Components.User
{
    [Route("users")]
    public class UserController : Controller
    {
        private readonly UserRepository _userRepository = new();
        
        [Authorize]
        [HttpGet]
        public IActionResult GetUser()
        {
            var email = HttpContext.User.Claims.FirstOrDefault(
                c => c.Type is ClaimTypes.Email && c.Value is not "")?.Value;

            return Json(_userRepository.GetUserByEmail(email));
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetUserById([FromRoute] long id)
        {
            return Json(_userRepository.GetUserById(id));
        }
    }
}