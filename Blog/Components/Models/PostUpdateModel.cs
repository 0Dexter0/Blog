using System;

namespace Blog.Components.Models
{
    public class PostUpdateModel
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime UpdateTime { get; set; }

        public PostUpdateModel()
        {
            UpdateTime = DateTime.Now;
        }
    }
}