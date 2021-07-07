using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using Blog.Models;
using Blog.Repositories;
using Blog.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Post
{
    [Route("posts")]
    public class PostController : Controller
    {
        private readonly PostRepository _postRepository = new();
        private readonly UserRepository _userRepository = new();
        
        [HttpGet]
        public IActionResult GetPosts(int page = 1)
        {
            int pageSize = 2;
            List<PostModel> posts = _postRepository.GetAll();

            PageViewModel vm = new(posts.Count, page, pageSize);

            if (!vm.HasNextPage && !vm.HasPreviousPage) return NotFound();
            
            return Json(posts.Skip((page - 1) * pageSize).Take(pageSize));
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetPostBuId([FromRoute] long id)
        {
            return Json(_postRepository.GetPostById(id));
        }

        [Authorize]
        [HttpPost]
        public IActionResult CreatePost([FromBody] CreatePostModel post)
        {
            string email = HttpContext.User.Claims.FirstOrDefault(c =>
                c.Type is ClaimTypes.Email)?.Value;
            UserModel creator = _userRepository.GetUserByEmail(email);

            PostModel newPost = new()
            {
                Title = post.Title,
                Content = post.Content,
                Published = DateTime.Now,
                LastEdited = DateTime.Now,
                CreatorId = creator.Id
            };
            _postRepository.Create(newPost);
            _userRepository.AddPost(creator, newPost);

            return Json(post);
        }

        [Authorize]
        [HttpPatch]
        [Route("{id}")]
        public IActionResult UpdatePost([FromRoute] long id, [FromBody] PostUpdateModel update)
        {
            string email = HttpContext.User.Claims.FirstOrDefault(c =>
                c.Type is ClaimTypes.Email)?.Value;
            UserModel creator = _userRepository.GetUserByEmail(email);
            PostModel post = _postRepository.GetPostById(id);

            if (post.CreatorId.Equals(creator.Id))
                return Json(_postRepository.Update(id, update));

            return Forbid();
        }

        [Authorize]
        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete([FromRoute] long id)
        {
            string email = HttpContext.User.Claims.FirstOrDefault(c =>
                c.Type is ClaimTypes.Email)?.Value;
            UserModel creator = _userRepository.GetUserByEmail(email);
            PostModel post = _postRepository.GetPostById(id);

            if (post.CreatorId.Equals(creator.Id))
            {
                _postRepository.Delete(post);
                return Ok();
            }
            
            return Forbid();
        }
    }
}