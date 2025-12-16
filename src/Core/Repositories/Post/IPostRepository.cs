
using EvalApi.Src.Models.Post;

namespace EvalApi.Src.Core.Repositories.Post
{
    public interface IPostRepository
    {
        Task<PostModel> CreatePostAsync(CreatePostModel createPostModel);
        Task<PostModel> GetPostByIdAsync(int postId);
        Task<List<PostModel>> GetPostsByUserIdAsync(int userId);
        Task<List<PostModel>> GetAllPostsAsync();
        // Task<PostModel> UpdatePostAsync(UpdatePostModel updatePostModel);
        Task DeletePostAsync(int postId);
    }
}
