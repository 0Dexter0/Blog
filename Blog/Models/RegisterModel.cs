namespace Blog.Models
{
    public class RegisterModel
    {
        public string Email { get; set; }
        public string UserName { get; set; }
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