using Microsoft.EntityFrameworkCore;
using EvalApi.Src.Models.User;
using EvalApi.Src.Core.Exceptions;
using EvalApi.Src.Core.Repositories.Entities;

namespace EvalApi.Src.Core.Repositories.User
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _appDbContext;

        public UserRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<UserModel> CreateUserAsync(CreateUserModel data)
        {
            var userEntity = new UserEntity
            {
                Name = data.Name,
                Username = data.Username,
                Email = data.Email
            };

            await _appDbContext.Users.AddAsync(userEntity);
            await _appDbContext.SaveChangesAsync();

            return new UserModel
            {
                Id = userEntity.Id,
                Name = userEntity.Name,
                Username = userEntity.Username,
                Email = userEntity.Email,
                Posts = null
            };
        }

        public async Task<List<UserModel>> GetUsersAsync()
        {
            var userEntities = await _appDbContext.Users.ToListAsync();
            if (userEntities == null || userEntities.Count == 0)
            {
                throw new UserNotFoundException(0); 
            }

            var userModels = userEntities.Select(userEntity => new UserModel
            {
                Id = userEntity.Id,
                Name = userEntity.Name,
                Username = userEntity.Username,
                Email = userEntity.Email,
                Posts = null
            }).ToList();

            return userModels;
        }
    }
}
