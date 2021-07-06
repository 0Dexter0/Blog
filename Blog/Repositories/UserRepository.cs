using System.Linq;
using Blog.Context;
using Blog.User;

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
                return ac.Users.FirstOrDefault(u => u.Email.Equals(email));
            }
        }
    }
}