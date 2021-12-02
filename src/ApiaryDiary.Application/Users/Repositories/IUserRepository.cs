using ApiaryDiary.Core.Users.Entities;
using System;
using System.Threading.Tasks;

namespace ApiaryDiary.Application.Users.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetAsync(Guid id);
        Task<User> GetAsync(string email);
        Task AddAsync(User user);
        Task UpdateAsync(User user);
    }
}