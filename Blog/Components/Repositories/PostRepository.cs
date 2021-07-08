using System.Collections.Generic;
using System.Linq;
using Blog.Components.Context;
using Blog.Components.Models;
using Blog.Components.Post;


namespace Blog.Components.Repositories
{
    public class PostRepository
    {
        public void Create(PostModel post)
        {
            using (ApplicationContext ac = new())
            {
                ac.Posts.Add(post);
                ac.SaveChanges();
            }
        }

        public PostModel Update(long id, PostUpdateModel update)
        {
            using (ApplicationContext ac = new())
            {
                PostModel post = GetPostById(id);

                if (update.Content is not null) post.Content = update.Content;
                if (update.Title is not null) post.Title = update.Title;
                post.LastEdited = update.UpdateTime;

                ac.Update(post);
                ac.SaveChanges();

                return post;
            }
        }

        public PostModel GetPostById(long id)
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

        public void Delete(PostModel post)
        {
            using (ApplicationContext ac = new())
            {
                ac.Posts.Remove(post);
                ac.SaveChanges();
            }
        }

        public List<PostModel> GetAll()
        {
            using (ApplicationContext ac = new())
            {
                return ac.Posts.ToList();
            }
        }
    }
}