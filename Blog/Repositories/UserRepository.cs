using System.Linq;
using Blog.Context;
using Blog.Post;
using Blog.User;
using Microsoft.EntityFrameworkCore;

namespace Blog.Repositories
{
    public class UserRepository
    {
        public void Create(UserModel user)
        {
            using (ApplicationContext ac = new())
            {
                ac.Users.Add(user);
                ac.SaveChanges();
            }
        }

        public UserModel GetUserById(long id)
        {
            using (ApplicationContext ac = new())
            {
                return ac.Users.FirstOrDefault(u => u.Id.Equals(id));
            }
        }
        
        public UserModel GetUserByEmail(string email)
        {
            using (ApplicationContext ac = new())
            {
                return ac.Users.Include(u => u.Posts)
                    .FirstOrDefault(u => u.Email.Equals(email));
            }
        }

        public UserModel AddPost(UserModel user, PostModel post)
        {
            using (ApplicationContext ac = new())
            {
                user.Posts.Add(post);
                ac.SaveChanges();
            }

            return user;
        }
    }
}