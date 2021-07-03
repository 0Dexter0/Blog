using System;
using System.Collections.Generic;
using Blog.Models;
using Blog.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Controllers
{
    [Route("posts")]
    public class PostController : Controller
    {
        private PostRepository _postRepository = new();
        
        [HttpGet]
        public List<Post> GetPosts()
        {
            /// TODO: add paging

            return _postRepository.GetAll();
        }

        [HttpGet]
        [Route("{id}")]
        public Post GetPostBuId([FromRoute] long id)
        {
            return _postRepository.GetPostById(id);
        }

        [Authorize]
        [HttpPost]
        public Post CreatePost([FromBody] Post post)
        {
            _postRepository.Create(post);

            return post;
        }

        [Authorize]
        [HttpPatch]
        [Route("{id}")]
        public Post UpdatePost([FromRoute] long id, [FromBody] PostUpdateModel update)
        {
            return  _postRepository.Update(id, update); 
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