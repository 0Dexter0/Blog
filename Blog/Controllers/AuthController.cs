using System.Security.Claims;
using System.Threading.Tasks;
using Blog.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Controllers
{
    [Route("auth")]
    public class AuthController : Controller
    {
        [HttpPost]
        [Route("login")]
        public async Task<User> Login([FromBody]LoginModel lm)
        {
            ClaimsIdentity claimsIdentity = new(new[]
            {
                new Claim(ClaimTypes.Email, lm.Email)
            }, "Cookie");
            ClaimsPrincipal claimsPrincipal = new(claimsIdentity);
            
            await HttpContext.SignInAsync("Cookie", claimsPrincipal);
            
            ///TODO: return user
            return null;
        }
        
        [HttpPost]
        [Route("register")]
        public async Task<User> Register([FromBody]RegisterModel rg)
        {
            User user = new(rg.UserName, rg.Email, rg.Password);
            ///TODO: add user to db

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