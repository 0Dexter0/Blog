using System.Collections.Generic;
using Blog.Components.Post;

namespace Blog.Components.User
{
    public class UserModel
    {
        public long Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public List<PostModel> Posts { get; set; }

        public UserModel()
        {
            Posts = new();
        }

        public UserModel(string userName, string email, string password)
        {
            UserName = userName;
            Email = email;
            Password = password;
            Posts = new();
        }
    }
}