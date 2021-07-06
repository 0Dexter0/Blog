using Blog.Models;
using Blog.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Post
{
    [Route("posts")]
    public class PostController : Controller
    {
        private readonly PostRepository _postRepository = new();
        
        [HttpGet]
        public IActionResult GetPosts()
        {
            /// TODO: add paging

            return Json(_postRepository.GetAll());
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetPostBuId([FromRoute] long id)
        {
            return Json(_postRepository.GetPostById(id));
        }

        [Authorize]
        [HttpPost]
        public IActionResult CreatePost([FromBody] PostModel post)
        {
            _postRepository.Create(post);

            return Json(post);
        }

        [Authorize]
        [HttpPatch]
        [Route("{id}")]
        public IActionResult UpdatePost([FromRoute] long id, [FromBody] PostUpdateModel update)
        {
            return  Json(_postRepository.Update(id, update)); 
        }

        [Authorize]
        [HttpDelete]
        [Route("{id}")]
        public void Delete([FromRoute] long id)
        {
            _postRepository.DeleteById(id);
        }
    }
}