
using EvalApi.Src.Core.Repositories.Post;
using EvalApi.Src.Models.Post;

namespace EvalApi.Src.Core.Services.Post
{
    public class PostService : IPostService
    {
        private readonly IPostRepository _postRepository;

        public PostService(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public async Task<PostModel> CreatePostAsync(CreatePostModel createPostModel)
        {
            return await _postRepository.CreatePostAsync(createPostModel);
        }

        public async Task<PostModel> GetPostByIdAsync(int postId)
        {
            return await _postRepository.GetPostByIdAsync(postId);
        }

        public async Task<List<PostModel>> GetPostsByUserIdAsync(int userId)
        {
            return await _postRepository.GetPostsByUserIdAsync(userId);
        }

        public async Task<List<PostModel>> GetAllPostsAsync()
        {
            return await _postRepository.GetAllPostsAsync();
        }

        // public async Task<PostModel> UpdatePostAsync(UpdatePostModel updatePostModel)
        // {
        //     return await _postRepository.UpdatePostAsync(updatePostModel);
        // }

        public async Task DeletePostAsync(int postId)
        {
            await _postRepository.DeletePostAsync(postId);
        }
    }
}

