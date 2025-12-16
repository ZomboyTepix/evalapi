using EvalApi.Src.Models.User;
using EvalApi.Src.Core.Repositories.User;

namespace EvalApi.Src.Core.Services.User
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Task<UserModel> CreateUserAsync(CreateUserModel user)
        {
            return _userRepository.CreateUserAsync(user);
        }

        public Task<List<UserModel>> GetUsersAsync()
        {
            return _userRepository.GetUsersAsync();
        }
    }
}
