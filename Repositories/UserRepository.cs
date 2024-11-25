using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RemoteMultiSiteMobileBasedExpenseManager.Models.UserModels;
using RemoteMultiSiteMobileBasedExpenseManager.SqlServer;

namespace RemoteMultiSiteMobileBasedExpenseManager.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DbContextEntities _context;

        public UserRepository(DbContextEntities context)
        {
            this._context = context;
        }
        public Users LoginUser(Users objUser)
        {
            var login = _context.Users.FirstOrDefault(x => x.Email == objUser.Email && x.Password == objUser.Password);
            if(login != null)
                return login;
            else
                return null;
        }
        public Users CreateUser(Users objUser)
        {
            //using (var transaction =  _context.Database.BeginTransaction())
            {
                var user = _context.Users.Where(x => x.Email == objUser.Email).FirstOrDefault();
                if (user == null)
                {
                    //_context.Database.ExecuteSqlInterpolated($"SET IDENTITY_INSERT Users.Users ON;");
                    _context.Users.Add(objUser);
                    _context.SaveChanges();
                    //_context.Database.ExecuteSqlInterpolated($"SET IDENTITY_INSERT Users.Users OFF;");
                }
                //transaction.Commit();
            }
            return objUser;
        }

        public Task DeleteUser(Users objUser)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Users>> ListAllUsers()
        {
            var listUsers = await _context.Users.ToListAsync();
            return listUsers;
        }
        public Task<List<Users>> ListAllProjectUsers(int ProjectId)
        {
            throw new NotImplementedException();
        }

        public Task<Users> ListUserById(int UserId)
        {
            throw new NotImplementedException();
        }
        public Task<Users> UpdateUser(Users objUser)
        {
            throw new NotImplementedException();
        }
    }
}
