using CRUDDemo3Frontend.Model;
using Microsoft.AspNetCore.Identity;
using NLog;
using static System.Net.WebRequestMethods;

namespace CRUDDemo3Frontend.Service
{
    public class UserService : IUserService
    {
        private readonly HttpClient httpClient;
        private static readonly Logger _logger = LogManager.GetCurrentClassLogger();

        public UserService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<List<User>> GetUsers()
        {
            _logger.Warn("User visited Index page");
            return await httpClient.GetFromJsonAsync<List<User>>("api/User/GetUsers");
        }

        public async Task<User> GetUser(int Id)
        {
            _logger.Warn("User visited details page");
            return await httpClient.GetFromJsonAsync<User>("api/User/GetUser/"+Id);
        }

        public async Task AddUser(User user)
        {
            _logger.Warn("User registered a new user");
            await httpClient.PostAsJsonAsync("api/User/AddUser", user);
        }

        public async Task DeleteUser(int Id)
        {
            _logger.Warn("User deleted an existing user");
            await httpClient.DeleteAsync("api/User/DeleteUser/"+Id);
        }

        public async Task UpdateUser(User user)
        {
            _logger.Warn("User updated an existing user");
            await httpClient.PutAsJsonAsync("api/User/UpdateUser", user);
        }

        public async Task<bool> ValidateUser(LoginUser user)
        {
            var result = await httpClient.PostAsJsonAsync("api/User/ValidateUser", user);
            if (result.IsSuccessStatusCode)
            {
                _logger.Warn("New user logged in");
            }
            else
            {
                _logger.Warn("User entered invalid credentials");
            }
            return result.IsSuccessStatusCode;
        }
    }
}
