using System;
using System.Collections.Generic;
using Blog.Components.Comment;

namespace Blog.Components.Post
{
    public class PostModel
    {
        public long Id { get; init; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime Published { get; init; }
        public DateTime LastEdited { get; set; }
        private List<CommentModel> Comments { get; set; }
        public long CreatorId { get; init; }

        public PostModel()
        {
            Comments = new();
        }
    }
}