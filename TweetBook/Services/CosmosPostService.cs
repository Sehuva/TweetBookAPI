using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cosmonaut;
using Cosmonaut.Extensions;
using TweetBook.Domain;

namespace TweetBook.Services
{
    public class CosmosPostService: IPostService
    {
        private readonly ICosmosStore<CosmosPostDTO> _cosmosStore;

        public CosmosPostService(ICosmosStore<CosmosPostDTO> cosmosStore)
        {
            _cosmosStore = cosmosStore;
        }

        public async Task<List<Post>> GetPosts()
        {
            var posts = await _cosmosStore.Query().ToListAsync();
            return posts.Select(x => new Post {Id = Guid.Parse(x.Id), Name = x.Name}).ToList();
        }

        public async Task<Post> GetPostById(Guid postId)
        {
            var post = await _cosmosStore.FindAsync(postId.ToString(), postId.ToString());
            return post == null ? null : new Post {Id = Guid.Parse(post.Id), Name = post.Name};
        }

        public async Task<bool> UpdatePost(Post postToUpdate)
        {
            var cosmosPost = new CosmosPostDTO
            {
                Id = postToUpdate.Id.ToString(),
                Name = postToUpdate.Name
            };
            var result = await _cosmosStore.UpdateAsync(cosmosPost);
            
            return result.IsSuccess;
        }

        public async Task<bool> DeletePost(Guid postId)
        {
            var result = await _cosmosStore.RemoveByIdAsync(postId.ToString(), postId.ToString());
            return result.IsSuccess;
        }

        public async Task<bool> CreatePost(Post post)
        {
            var cosmosPost = new CosmosPostDTO
            {
                Id = Guid.NewGuid().ToString(),
                Name = post.Name
            };
            var result = await _cosmosStore.AddAsync(cosmosPost);
            
            return result.IsSuccess;
        }
    }
}