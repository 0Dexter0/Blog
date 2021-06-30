using System;

namespace Blog.Models
{
    public class Comment
    {
        public long Id { get; init; }
        public string Content { get; set; }
        public DateTime Published { get; init; }
        public DateTime LastEdited { get; set; }

        public Post Post { get; set; }
        public long PostId { get; init; }
        
        public User Creator { get; init; }
        public long CreatorId { get; init; }

        public Comment()
        {
            Published = DateTime.Now;
        }
    }
}