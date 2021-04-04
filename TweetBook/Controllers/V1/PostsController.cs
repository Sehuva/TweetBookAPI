using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using TweetBook.Contracts.Request;
using TweetBook.Contracts.Response;
using TweetBook.Contracts.V1;
using TweetBook.Domain;
using TweetBook.Services;

namespace TweetBook.Controllers.V1
{
    public class PostsController: Controller
    {
        private readonly IPostService _postService;

        public PostsController(IPostService postService)
        {
            _postService = postService;
        }
        
        [HttpGet(ApiRoutes.Posts.GetAll)]
        public IActionResult GetAll()
        {
            return Ok(_postService.GetPosts());
        }

        [HttpGet(ApiRoutes.Posts.Get)]
        public IActionResult Get(Guid postId)
        {
            var post = _postService.GetPostById(postId);
            if (post == null)
                return NotFound();
            
            return Ok(post);
        }
        [HttpPost(ApiRoutes.Posts.Create)]
        public IActionResult Post([FromBody] CreatePostRequest postRequest)
        {
            var post = new Post
            {
                Id = Guid.NewGuid(),
                Name = postRequest.Name
            };

            _postService.GetPosts().Add(post);
            var baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";
            var resourceLocation = baseUrl + "/" + ApiRoutes.Posts.Get.Replace("{postId}", post.Id.ToString());
            
            var response = new PostResponse
            {
                Id = post.Id
            };
            return Created(resourceLocation, response);
        }
        
        [HttpPut(ApiRoutes.Posts.Update)]
        public IActionResult Update([FromRoute] Guid postId, [FromBody] Post postToUpdate)
        {
            var post = new Post
            {
                Id = postId,
                Name = postToUpdate.Name
            };
            
            var updated = _postService.UpdatePost(post);
            if (updated)
                return Ok(post);

            return NotFound();
        }
        
        [HttpDelete(ApiRoutes.Posts.Delete)]
        public IActionResult Update([FromRoute] Guid postId)
        {
            var deleted = _postService.DeletePost(postId);
            if (deleted)
                return NoContent();

            return NotFound();
        }
        
    }
}