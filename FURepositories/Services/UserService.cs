using FUBusiness.Data.Entities;
using FURepositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FUDataAccess.Interfaces;

namespace FURepositories.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            Console.WriteLine("Fetching all users...");
            var users = await _userRepository.GetAllAsync();
            Console.WriteLine($"Retrieved {users.Count()} users.");
            return users;
        }

        public async Task<User?> GetUserByIdAsync(int id)
        {
            Console.WriteLine($"Fetching user with ID: {id}");
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null)
                Console.WriteLine($"No user found with ID: {id}");
            else
                Console.WriteLine($"User found: {user.FullName} ({user.Email})");
            return user;
        }

        public async Task<User?> AuthenticateAsync(string identifier, string password)
        {
            Console.WriteLine($"Attempting login for: {identifier}");
            var user = await _userRepository.AuthenticateAsync(identifier, password);
            if (user == null)
                Console.WriteLine("Authentication failed.");
            else
                Console.WriteLine($"Authenticated as: {user.FullName} ({user.Email}), Role: {user.Role}");
            return user;
        }

        public async Task<bool> RegisterAsync(string name, string email, string password, int role)
        {
            Console.WriteLine($"Attempting to register: {name}, {email}, Role: {role}");
            var result = await _userRepository.RegisterAsync(name, email, password, role);
            if (result)
                Console.WriteLine("Registration successful.");
            else
                Console.WriteLine("Registration failed (email might already exist).");
            return result;
        }

        public async Task UpdateUserAsync(User user)
        {
            Console.WriteLine($"Updating user: {user.FullName} (ID: {user.Id})");
            await _userRepository.UpdateAsync(user);
            await _userRepository.SaveChangesAsync();
            Console.WriteLine("Update completed.");
        }

        public async Task DeleteUserAsync(int id)
        {
            Console.WriteLine($"Attempting to delete user with ID: {id}");
            var user = await _userRepository.GetByIdAsync(id);
            if (user != null)
            {
                await _userRepository.DeleteAsync(user);
                await _userRepository.SaveChangesAsync();
                Console.WriteLine($"User {user.FullName} deleted.");
            }
            else
            {
                Console.WriteLine($"User with ID {id} not found. Delete aborted.");
            }
        }
    }
}
