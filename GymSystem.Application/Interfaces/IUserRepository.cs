using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GymSystem.Domain.Entities;

namespace GymSystem.Application.Interfaces
{
    public  interface IUserRepository
    {
        Task<User> getByIdAsync(int id);

        Task<User> getByEmailAsync(string email);

        Task<List<User>> GetAllAsync();

        Task<User> AddAsync(User user);

        Task<User> UpdateAsync(User user);
        Task<bool> DeleteAsync(int id);

        Task<bool> ExistsAsync(int id);  

        Task<bool> EmailExistsAsync(String email);


    }
}
