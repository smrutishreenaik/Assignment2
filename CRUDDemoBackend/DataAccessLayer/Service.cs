using Dapper;
using DataAccessLayer.DbContext;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class Service
    {
        private readonly DapperContext context;

        public Service(DapperContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            var query = "SELECT * FROM [User]";

            using (var connection = context.CreateConnection())
            {
                var users = await connection.QueryAsync<User>(query);
                return users.ToList();
            }
        }

        public async Task<User> GetUser(int Id)
        {
            var query = "SELECT * FROM [User] WHERE Id = @Id";

            using (var connection = context.CreateConnection())
            {
                var user = await connection.QuerySingleOrDefaultAsync<User>(query, new { Id });
                return user;
            }
        }

        public async Task<bool> ValidateEmailAndPassword(LoginUser loginUser)
        {
            var query = "SELECT * FROM [User] WHERE EmailAddress = @EmailAddress";
            using (var connection = context.CreateConnection())
            {
                var user = await connection.QuerySingleOrDefaultAsync<User>(query, new { loginUser.EmailAddress });
                return user!=null && user.Password==loginUser.Password;
            }
        }

        public async Task AddUser(User user)
        {
            var query = "INSERT INTO [User] (UserID, Password, FullName,EmailAddress) VALUES (@UserID, @Password, @FullName, @EmailAddress)";

            var parameters = new DynamicParameters();
            parameters.Add("UserID", user.UserID, DbType.String);
            parameters.Add("Password", user.Password, DbType.String);
            parameters.Add("FullName", user.FullName, DbType.String);
            parameters.Add("EmailAddress", user.EmailAddress, DbType.String);

            using (var connection = context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task UpdateUser(User user)
        {
            var query = "UPDATE [User]  set UserID = @UserID, Password = @Password, FullName = @FullName, EmailAddress = @EmailAddress where Id = @Id";
            var parameters = new DynamicParameters();
            parameters.Add("id", user.Id, DbType.Int64);
            parameters.Add("UserID", user.UserID, DbType.String);
            parameters.Add("Password", user.Password, DbType.String);
            parameters.Add("FullName", user.FullName, DbType.String);
            parameters.Add("EmailAddress", user.EmailAddress, DbType.String);
            using (var connection = context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task DeleteUser(int Id)
        {
            var query = "DELETE FROM [User] WHERE Id = @Id";
            using (var connection = context.CreateConnection())
            {
                await connection.ExecuteAsync(query, new { Id });
            }
        }
    }
}
