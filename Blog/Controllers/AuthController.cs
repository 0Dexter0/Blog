using System.Security.Claims;
using System.Threading.Tasks;
using Blog.Models;
using Blog.Repositories;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Controllers
{
    [Route("auth")]
    public class AuthController : Controller
    {
        private UserRepository _userRepository = new();

        [HttpPost]
        [Route("login")]
        public async Task<User> Login([FromBody]LoginModel lm)
        {
            if (!ModelState.IsValid) return null;
            
            ClaimsIdentity claimsIdentity = new(new[]
            {
                new Claim(ClaimTypes.Email, lm.Email)
            }, "Cookie");
            ClaimsPrincipal claimsPrincipal = new(claimsIdentity);

            User user = _userRepository.GetUserByEmail(lm.Email);

            if (user.Password.Equals(lm.Password))
            {
                await HttpContext.SignInAsync("Cookie", claimsPrincipal);
                return user;
            }

            return null;
            /// TODO: add password encryption
        }
        
        [HttpPost]
        [Route("register")]
        public async Task<User> Register([FromBody]RegisterModel rg)
        {
            if (!ModelState.IsValid) return null;

            /// TODO: add password encryption
            /// TODO: add a check for user existence
            User user = new(rg.UserName, rg.Email, rg.Password);
            _userRepository.Create(user);

            ClaimsIdentity claimsIdentity = new(new[]
            {
                new Claim(ClaimTypes.Email, rg.Email)
            }, "Cookie");
            ClaimsPrincipal claimsPrincipal = new(claimsIdentity);

            await HttpContext.SignInAsync("Cookie", claimsPrincipal);
            
            return user;
        }
        
        [HttpGet]
        [Route("logout")]
        public void LogOut()
        {
            HttpContext.SignOutAsync("Cookie");
            Redirect("/home");
        }
    }
}