using System.Security.Claims;
using System.Threading.Tasks;
using Blog.Models;
using Blog.User;
using Blog.Repositories;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Auth
{
    [Route("auth")]
    public class AuthController : Controller
    {
        private readonly UserRepository _userRepository = new();

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody]LoginModel lm)
        {
            if (!ModelState.IsValid) return StatusCode(404);
            
            ClaimsIdentity claimsIdentity = new(new[]
            {
                new Claim(ClaimTypes.Email, lm.Email)
            }, "Cookie");
            ClaimsPrincipal claimsPrincipal = new(claimsIdentity);

            UserModel user = _userRepository.GetUserByEmail(lm.Email);

            if (user.Password.Equals(lm.Password))
            {
                await HttpContext.SignInAsync("Cookie", claimsPrincipal);
                return Json(user);
            }

            return StatusCode(403);
            /// TODO: add password encryption
        }
        
        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody]RegisterModel rg)
        {
            if (!ModelState.IsValid) return StatusCode(404);

            /// TODO: add password encryption
            /// TODO: add a check for user existence
            UserModel user = new(rg.UserName, rg.Email, rg.Password);
            _userRepository.Create(user);

            ClaimsIdentity claimsIdentity = new(new[]
            {
                new Claim(ClaimTypes.Email, rg.Email)
            }, "Cookie");
            ClaimsPrincipal claimsPrincipal = new(claimsIdentity);

            await HttpContext.SignInAsync("Cookie", claimsPrincipal);
            
            return Json(user);
        }
        
        [HttpPost]
        [Route("logout")]
        public void LogOut()
        {
            HttpContext.SignOutAsync("Cookie");
            Redirect("/home");
        }
    }
}