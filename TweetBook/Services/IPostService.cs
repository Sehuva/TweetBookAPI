using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TweetBook.Contracts.V1;
using TweetBook.Domain;

namespace TweetBook.Services
{
    public interface IPostService
    {
        Task<List<Post>> GetPosts();
        Task<Post> GetPostById(Guid postId);

        Task<bool> UpdatePost(Post postToUpdate);
        Task<bool> DeletePost(Guid postId);

        Task<bool> CreatePost(Post post);
    }
}