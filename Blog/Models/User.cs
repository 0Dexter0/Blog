using System.Collections.Generic;

namespace Blog.Models
{
    public class User
    {
        public long Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public List<Post> Posts { get; set; }

        public User()
        {
            Posts = new();
        }

        public User(string userName, string email, string password)
        {
            UserName = userName;
            Email = email;
            Password = password;
            Posts = new();
        }
    }
}