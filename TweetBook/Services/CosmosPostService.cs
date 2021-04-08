using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TweetBook.Domain;

namespace TweetBook.Services
{
    public class CosmosPostService: IPostService
    {
        public Task<List<Post>> GetPosts()
        {
            throw new NotImplementedException();
        }

        public Task<Post> GetPostById(Guid postId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdatePost(Post postToUpdate)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeletePost(Guid postId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> CreatePost(Post post)
        {
            throw new NotImplementedException();
        }
    }
}