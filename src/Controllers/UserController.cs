using Microsoft.AspNetCore.Mvc;
using EvalApi.Src.Views.Dto.User;
using EvalApi.Src.Models.User;
using EvalApi.Src.Core.Services.User;

namespace EvalApi.Src.Controllers;

public class UserController : BaseController<UserController>
{
    private readonly IUserService _userService;

    public UserController(ILogger<UserController> logger, IUserService userService) : base(logger)
    {
        _userService = userService;
    }

    [HttpPost]
    public async Task<ActionResult<UserDto>> CreateUser([FromBody] CreateUserDto createUserDto)
    {
        var createUserModel = new CreateUserModel
        {
            Name = createUserDto.name,
            Username = createUserDto.username,
            Email = createUserDto.email
        };

        var userModel = await _userService.CreateUserAsync(createUserModel);

        var userDto = new UserDto
        {
            id = userModel.Id,
            name = userModel.Name,
            username = userModel.Username,
            email = userModel.Email
        };

        return CreatedAtAction(nameof(CreateUser), null, userDto);
    }

    [HttpGet]
    public async Task<ActionResult<List<UserDto>>> GetUsers()
    {
        var userModels = await _userService.GetUsersAsync();

        var userDtos = userModels.Select(userModel => new UserDto
        {
            id = userModel.Id,
            name = userModel.Name,
            username = userModel.Username,
            email = userModel.Email
        }).ToList();

        return Ok(userDtos);
    }
}