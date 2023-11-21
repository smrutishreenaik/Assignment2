using CRUDDemo3Frontend.Model;
using Microsoft.Extensions.Logging;
using NLog;

namespace CRUDDemo3Frontend.Service
{
    public interface IUserService
    {
        public Task<List<User>> GetUsers();
        public Task AddUser(User user);
        public Task<User> GetUser(int Id);
        public Task DeleteUser(int Id);
        public Task UpdateUser(User user);
        public Task<bool> ValidateUser(LoginUser user);
    }
}
