using System.Collections.Generic;
using Blog.Components.Post;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace Blog.Tests
{
    public class PostControllerTests
    {
        [Fact]
        public void GetPosts()
        {
            PostController postController = new();

            JsonResult json = postController.GetPosts() as JsonResult;

            var posts = json!.Value as IEnumerable<PostModel>;
            
            Assert.NotNull(json);
            Assert.NotEmpty(posts!);
        }

        [Fact]
        public void GetPostById()
        {
            PostController postController = new();
            
            JsonResult json = postController.GetPostBuId(4) as JsonResult;
            PostModel post = json!.Value as PostModel;
            
            Assert.NotNull(post);
        }
    }
}