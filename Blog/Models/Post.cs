using System;
using System.Collections.Generic;

namespace Blog.Models
{
    public class Post
    {
        public long Id { get; init; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime Published { get; init; }
        public DateTime LastEdited { get; set; }
        private List<Comment> Comments { get; set; }
        
        public User Creator { get; init; }
        public long CreatorId { get; init; }

        public Post()
        {
            Comments = new();
        }
    }
}