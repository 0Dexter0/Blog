using System.Collections.Generic;

namespace Blog.Models
{
    public class IndexViewModel<T>
    {
        public IEnumerable<T> Elements { get; set; }
        public PageViewModel PageViewModel { get; set; }
    }
}