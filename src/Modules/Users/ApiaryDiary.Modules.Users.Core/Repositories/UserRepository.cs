using ApiaryDiary.Modules.Users.Core.Entities;

namespace ApiaryDiary.Modules.Users.Core.Repositories
{
    public class UserRepository : IUserRepository
    {
        private static IList<User> _users = new List<User>();

        public async Task AddAsync(User user)
        {
            _users.Add(user);
            await Task.CompletedTask;
        }

        public async Task<User> GetAsync(Guid id) 
            => await Task.FromResult(_users.SingleOrDefault(x => x.Id == id));

        public async Task<User> GetAsync(string email)
            => await Task.FromResult(_users.SingleOrDefault(x => x.Email == email));

        public async Task<User> GetByGuidAsync(string guid)
        => await Task.FromResult(_users.SingleOrDefault(x => x.UserActivationToken == guid));

        public async Task UpdateAsync(User user)
        {
            await Task.CompletedTask;
        }
    }
}
