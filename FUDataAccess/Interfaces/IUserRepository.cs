using FUBusiness.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FUDataAccess.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        //login
        Task<User?> AuthenticateAsync(string identifier, string password);
        Task<bool> RegisterAsync(string name, string email, string password, int role);
    }
}
