using EvalApi.Src.Models.User;

namespace EvalApi.Src.Core.Services.User
{
    public interface IUserService
    {
        Task<UserModel> CreateUserAsync(CreateUserModel user);
        Task<List<UserModel>> GetUsersAsync();
    }
}
