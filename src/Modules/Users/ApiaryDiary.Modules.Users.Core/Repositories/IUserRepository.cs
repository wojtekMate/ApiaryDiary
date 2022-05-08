using ApiaryDiary.Modules.Users.Core.Entities;

namespace ApiaryDiary.Modules.Users.Core.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetAsync(Guid id);
        Task<User> GetAsync(string email);
        Task<User> GetByGuidAsync(string guid);
        Task AddAsync(User user);
        Task UpdateAsync(User user);
    }
}