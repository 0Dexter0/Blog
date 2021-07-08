using System;
using Blog.Components.Post;
using Blog.Components.User;

namespace Blog.Components.Comment
{
    public class CommentModel
    {
        public long Id { get; init; }
        public string Content { get; set; }
        public DateTime Published { get; init; }
        public DateTime LastEdited { get; set; }

        public PostModel Post { get; set; }
        public long PostId { get; init; }
        
        public UserModel Creator { get; init; }
        public long CreatorId { get; init; }

        public CommentModel()
        {
            Published = DateTime.Now;
            LastEdited = Published;
        }
    }
}