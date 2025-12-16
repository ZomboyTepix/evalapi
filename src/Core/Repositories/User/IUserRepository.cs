using EvalApi.Src.Models.User;

namespace EvalApi.Src.Core.Repositories.User
{
    public interface IUserRepository
    {
        Task<UserModel> CreateUserAsync(CreateUserModel user);
        Task<List<UserModel>> GetUsersAsync();
    }
}
