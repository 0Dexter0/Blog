namespace Blog.Models
{
    public class LoginModel
    {
        public string Email { get; set; }
        public string Passwod { get; set; }

        public LoginModel(string email, string passwod)
        {
            Email = email;
            Passwod = passwod;
        }

        public LoginModel()
        {
        }
    }
}