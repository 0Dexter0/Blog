using System.ComponentModel.DataAnnotations;

namespace Blog.Models
{
    public class LoginModel
    {
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }

        public LoginModel(string email, string passwod)
        {
            Email = email;
            Password = passwod;
        }

        public LoginModel()
        {
        }
    }
}