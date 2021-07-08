using System;

namespace Blog.Components.Models
{
    public class PageViewModel
    {
        public int PageNumber { get; init; }
        public int TotalPages { get; init; }
 
        public PageViewModel(int count, int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
        }
 
        public bool HasPreviousPage => (PageNumber > 1);

        public bool HasNextPage => (PageNumber < TotalPages);
    }
}