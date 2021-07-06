using System;
using System.Collections.Generic;
using Blog.Comment;
using Blog.User;

namespace Blog.Post
{
    public class PostModel
    {
        public long Id { get; init; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime Published { get; init; }
        public DateTime LastEdited { get; set; }
        private List<CommentModel> Comments { get; set; }
        
        public UserModel Creator { get; init; }
        public long CreatorId { get; init; }

        public PostModel()
        {
            Comments = new();
        }
    }
}