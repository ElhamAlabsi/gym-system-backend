using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GymSystem.Application.Interfaces;
using GymSystem.Domain.Entities;
using Microsoft.VisualBasic;



namespace GymSystem.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly GymDbContext _context;
        
        public UserRepository(GymDbContext context)
        {
            _context = context;
        }

        public async Task<User> AddAsync(User user)
        {
           _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<bool> DeleteAsync(int id)
        {
          var user =  await _context.Users.FindAsync(id);
            if (user == null) return false;

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> EmailExistsAsync(string email)
        {
            return await _context.Users.AnyAsync(u => u.Email == email);

        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.Users.AnyAsync(u => u.Id == id);
        }

        public async Task<List<User>> getAllAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public Task<List<User>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<User> getByEmailAsync(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);

        }

        public async Task<User> getByIdAsync(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<User> UpdateAsync(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
            return user;
        }

    }
}
