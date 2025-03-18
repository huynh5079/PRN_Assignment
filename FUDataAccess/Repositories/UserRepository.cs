using FUBusiness.Data;
using FUBusiness.Data.Entities;
using FUDataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FUBusiness.Data;
using Microsoft.EntityFrameworkCore;
using FUDataAccess.Utilities;

namespace FUDataAccess.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DatabaseContext _context;

        public UserRepository(DatabaseContext context)
        {
            _context = context;
        }

        public async Task AddAsync(User user)
        {
            await _context.Users.AddAsync(user);
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User?> GetByIdAsync(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task UpdateAsync(User user)
        {
            _context.Users.Update(user);
        }

        public Task DeleteAsync(User user)
        {
            _context.Users.Remove(user);
            return Task.CompletedTask;
        }
        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        // Authenticate user by email or fullname and verify password
        public async Task<User?> AuthenticateAsync(string identifier, string password)
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.Email == identifier || u.FullName == identifier);

            if (user == null) return null;

            var passwordMatch = PasswordHasher.VerifyPassword(password, user.Password);
            return passwordMatch ? user : null;
        }

        // Register a new user
        public async Task<bool> RegisterAsync(string name, string email, string password, int role)
        {
            var existingUser = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
            if (existingUser != null)
            {
                // Email already exists
                return false;
            }

            var hashedPassword = PasswordHasher.HashPassword(password);
            var newUser = new User
            {
                FullName = name,
                Email = email,
                Password = hashedPassword,
                Role = role == 1 ? "Admin" : "Student", // convert role int to string if needed
                CreatedAt = DateTime.Now
            };

            await _context.Users.AddAsync(newUser);
            await _context.SaveChangesAsync();
            return true;
        }

    }
}
