
using Microsoft.AspNetCore.Mvc;
using RemoteMultiSiteMobileBasedExpenseManager.Models.UserModels;

namespace RemoteMultiSiteMobileBasedExpenseManager.Repositories
{
    public interface IUserRepository
    {
        public Users LoginUser(Users objUser);
        public Users CreateUser(Users objUser);
        public Task<Users> UpdateUser(Users objUser);
        public Task DeleteUser(Users objUser);
        public Task<List<Users>> ListAllProjectUsers(int ProjectId);
        public Task<List<Users>> ListAllUsers();
        public Task<Users> ListUserById(int UserId);
    }
}
