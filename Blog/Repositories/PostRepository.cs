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

        public Post Update(long id, PostUpdateModel update)
        {
            using (ApplicationContext ac = new())
            {
                Post post = GetPostById(id);

                if (update.Content is not null) post.Content = update.Content;
                if (update.Title is not null) post.Title = update.Title;
                post.LastEdited = update.UpdateTime;

                ac.SaveChanges();

                return post;
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