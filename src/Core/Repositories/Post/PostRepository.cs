
using EvalApi.Src.Models.Post;

namespace EvalApi.Src.Core.Repositories.Post
{
    public class PostRepository : IPostRepository
    {
        // In-memory storage for demonstration
        private static List<PostModel> _posts = new List<PostModel>();
        private static int _nextId = 1;

        public async Task<PostModel> CreatePostAsync(CreatePostModel createPostModel)
        {
            var post = new PostModel
            {
                Id = _nextId++,
                UserId = createPostModel.UserId,
                Title = createPostModel.Title,
                Body = createPostModel.Body
            };
            _posts.Add(post);
            return await Task.FromResult(post);
        }

        public async Task<PostModel> GetPostByIdAsync(int postId)
        {
            var post = _posts.Find(p => p.Id == postId);
            return await Task.FromResult(post);
        }

        public async Task<List<PostModel>> GetPostsByUserIdAsync(int userId)
        {
            var posts = _posts.FindAll(p => p.UserId == userId);
            return await Task.FromResult(posts);
        }

        public async Task<List<PostModel>> GetAllPostsAsync()
        {
            return await Task.FromResult(new List<PostModel>(_posts));
        }

        // public async Task<PostModel> UpdatePostAsync(UpdatePostModel updatePostModel)
        // {
        //     var post = _posts.Find(p => p.Id == updatePostModel.Id);
        //     if (post != null)
        //     {
        //         post.Title = updatePostModel.Title;
        //         post.Body = updatePostModel.Body;
        //     }
        //     return await Task.FromResult(post);
        // }

        public async Task DeletePostAsync(int postId)
        {
            var post = _posts.Find(p => p.Id == postId);
            if (post != null)
            {
                _posts.Remove(post);
            }
            await Task.CompletedTask;
        }
    }
}
