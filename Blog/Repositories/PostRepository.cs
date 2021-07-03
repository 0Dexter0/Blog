using System.Collections.Generic;
using System.Linq;
using Blog.Context;
using Blog.Models;

namespace Blog.Repositories
{
    public class PostRepository
    {
        public void Create(Post post)
        {
            using (ApplicationContext ac = new())
            {
                ac.Posts.Add(post);
                ac.SaveChanges();
            }
        }

        public void Update(long id, PostUpdateModel update)
        {
            using (ApplicationContext ac = new())
            {
                Post _post = GetPostById(id);

                if (update.Content is not null) _post.Content = update.Content;
                if (update.Title is not null) _post.Title = update.Title;
                _post.LastEdited = update.UpdateTime;

                ac.SaveChanges();
            }
        }

        public Post GetPostById(long id)
        {
            using (ApplicationContext ac = new())
            {
                return ac.Posts.FirstOrDefault(p => p.Id.Equals(id));
            }
        }

        public void DeleteById(long id)
        {
            using (ApplicationContext ac = new())
            {
                ac.Posts.Remove(GetPostById(id));
                ac.SaveChanges();
            }
        }

        public void Delete(Post post)
        {
            using (ApplicationContext ac = new())
            {
                ac.Posts.Remove(post);
                ac.SaveChanges();
            }
        }

        public List<Post> GetAll()
        {
            using (ApplicationContext ac = new())
            {
                return ac.Posts.ToList();
            }
        }
    }
}