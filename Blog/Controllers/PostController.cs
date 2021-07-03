using System;
using System.Collections.Generic;
using Blog.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Controllers
{
    [Route("posts")]
    public class PostController : Controller
    {
        [HttpGet]
        public List<Post> GetPosts()
        {
            /// TODO: return posts from db
            /// TODO: add paging

            return null;
        }

        [HttpGet]
        [Route("{id}")]
        public Post GetPostBuId([FromRoute] long id)
        {
            /// TODO: get post by id from db

            return null;
        }

        [Authorize]
        [HttpPost]
        public Post CreatePost([FromBody] Post post)
        {
            /// TODO: add post to db

            return post;
        }

        [Authorize]
        [HttpPatch]
        [Route("{id}")]
        public Post UpdatePost([FromRoute] long id, [FromBody] PostUpdateModel update)
        {
            /// TODO: get post from db and update

            return null;
        }

        [Authorize]
        [HttpDelete]
        [Route("{id}")]
        public Post Delete([FromRoute] long id)
        {
            /// TODO: remove post from db

            return null;
        }
    }
}