using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Blog.Models;
using Blog.User;
using Blog.Repositories;
using Microsoft.AspNetCore.Authentication;
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
            if (!ModelState.IsValid) return ValidationProblem();
            
            ClaimsIdentity claimsIdentity = new(new[]
            {
                new Claim(ClaimTypes.Email, lm.Email)
            }, "Cookie");
            ClaimsPrincipal claimsPrincipal = new(claimsIdentity);

            UserModel user = _userRepository.GetUserByEmail(lm.Email);

            if (user is null) return NotFound();
            
            if (BCrypt.Net.BCrypt.Verify(lm.Password, user.Password))
            {
                await HttpContext.SignInAsync("Cookie", claimsPrincipal);
                return Json(user);
            }

            return BadRequest();
        }
        
        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody]RegisterModel rg)
        {
            if (!ModelState.IsValid) return ValidationProblem();

            if (_userRepository.GetUserByEmail(rg.Email) is not null) return BadRequest(); /// TODO: return correct status code

            string password = BCrypt.Net.BCrypt.HashPassword(rg.Password);
            UserModel user = new(rg.UserName, rg.Email, password);
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