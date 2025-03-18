using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FUBusiness.Data.Entities;

namespace FURepositories.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task<User?> GetUserByIdAsync(int id);
        Task<User?> AuthenticateAsync(string identifier, string password);
        Task<bool> RegisterAsync(string name, string email, string password, int role);
        Task UpdateUserAsync(User user);
        Task DeleteUserAsync(int id);
    }
}
