using System.ComponentModel.DataAnnotations;

namespace Blog.Models
{
    public class RegisterModel
    {
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }

        public RegisterModel(string email, string userName, string password)
        {
            Email = email;
            UserName = userName;
            Password = password;
        }

        public RegisterModel()
        {
        }
    }
}