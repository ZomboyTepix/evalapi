
using Microsoft.AspNetCore.Mvc;
using EvalApi.Src.Views.Dto.Post;
using EvalApi.Src.Models.Post;
using EvalApi.Src.Core.Services.Post;

namespace EvalApi.Src.Controllers;

public class PostController : BaseController<PostController>
{
    private readonly IPostService _postService;

    public PostController(ILogger<PostController> logger, IPostService postService) : base(logger)
    {
        _postService = postService;
    }

    // POST api/users/{userId}/posts
    [HttpPost("users/{userId}/posts")]
    public async Task<ActionResult<PostDto>> CreatePost(int userId, [FromBody] CreatePostDto createPostDto)
    {
        if (createPostDto == null)
            return BadRequest("Body required");

        if (userId <= 0 || createPostDto.userId != userId)
            return BadRequest("userId mismatch or invalid userId");

        if (string.IsNullOrWhiteSpace(createPostDto.title))
            return BadRequest("title required and non-empty");
        if (string.IsNullOrWhiteSpace(createPostDto.body))
            return BadRequest("body required and non-empty");

        var createModel = new CreatePostModel
        {
            UserId = userId,
            Title = createPostDto.title,
            Body = createPostDto.body
        };

        var postModel = await _postService.CreatePostAsync(createModel);

        var postDto = new PostDto
        {
            id = postModel.Id,
            userId = postModel.UserId,
            title = postModel.Title,
            body = postModel.Body
        };

        return CreatedAtAction(nameof(GetPostById), new { postId = postDto.id }, postDto);
    }

    // GET api/users/{userId}/posts
    [HttpGet("users/{userId}/posts")]
    public async Task<ActionResult<List<PostDto>>> GetPostsByUser(int userId)
    {
        if (userId <= 0)
            return BadRequest("Invalid userId");

        var postModels = await _postService.GetPostsByUserIdAsync(userId);

        var postDtos = postModels.Select(postModel => new PostDto
        {
            id = postModel.Id,
            userId = postModel.UserId,
            title = postModel.Title,
            body = postModel.Body
        }).ToList();

        return Ok(postDtos);
    }

    // GET api/posts/{postId}
    [HttpGet("posts/{postId}")]
    public async Task<ActionResult<PostDto>> GetPostById(int postId)
    {
        if (postId <= 0)
            return BadRequest("Invalid postId");

        var postModel = await _postService.GetPostByIdAsync(postId);
        if (postModel == null)
            return NotFound();

        var postDto = new PostDto
        {
            id = postModel.Id,
            userId = postModel.UserId,
            title = postModel.Title,
            body = postModel.Body
        };

        return Ok(postDto);
    }

    // PUT api/posts/{postId}
    // [HttpPut("posts/{postId}")]
    // public async Task<ActionResult<PostDto>> UpdatePost(int postId, [FromBody] PostDto postDto)
    // {
    //     if (postDto == null)
    //         return BadRequest("Body required");
    //     if (postDto.id != postId || postId <= 0)
    //         return BadRequest("PostId mismatch or invalid postId");
    //     if (postDto.userId <= 0)
    //         return BadRequest("Invalid userId");
    //     if (string.IsNullOrWhiteSpace(postDto.title))
    //         return BadRequest("title required and non-empty");
    //     if (string.IsNullOrWhiteSpace(postDto.body))
    //         return BadRequest("body required and non-empty");

    //     var existingPostModel = await _postService.GetPostByIdAsync(postId);
    //     if (existingPostModel == null)
    //         return NotFound();

    //     if (existingPostModel.UserId != postDto.userId)
    //         return BadRequest("userId in DTO does not match userId of the post");

    //     var updateModel = new UpdatePostModel
    //     {
    //         Id = postId,
    //         Title = postDto.title,
    //         Body = postDto.body
    //     };

    //     var updatedPostModel = await _postService.UpdatePostAsync(updateModel);

    //     var updatedPostDto = new PostDto
    //     {
    //         id = updatedPostModel.Id,
    //         userId = updatedPostModel.UserId,
    //         title = updatedPostModel.Title,
    //         body = updatedPostModel.Body
    //     };

    //     return Ok(updatedPostDto);
    // }

    // DELETE api/posts/{postId}
    [HttpDelete("posts/{postId}")]
    public async Task<IActionResult> DeletePost(int postId)
    {
        if (postId <= 0)
            return BadRequest("Invalid postId");

        var postModel = await _postService.GetPostByIdAsync(postId);
        if (postModel == null)
            return NotFound();

        await _postService.DeletePostAsync(postId);

        return NoContent();
    }
}


