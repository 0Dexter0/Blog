using System.Linq;
using Blog.Context;
using Blog.Models;

namespace Blog.Repositories
{
    public class UserRepository
    {
        public void Create(User user)
        {
            using (ApplicationContext ac = new())
            {
                ac.Users.Add(user);
                ac.SaveChanges();
            }
        }

        public User GetUserById(long id)
        {
            using (ApplicationContext ac = new())
            {
                return ac.Users.FirstOrDefault(u => u.Id.Equals(id));
            }
        }
        
        public User GetUserByEmail(string email)
        {
            using (ApplicationContext ac = new())
            {
                return ac.Users.FirstOrDefault(u => u.Email.Equals(email));
            }
        }
    }
}