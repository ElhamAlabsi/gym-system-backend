using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GymSystem.Application.DTOs.AuthDtos;
using GymSystem.Application.Interfaces;
using GymSystem.Domain.Entities;
using GymSystem.Domain.Entities;

namespace GymSystem.Application.Services
{
    public class UserService :IUserService
    {

        private readonly IUserRepository _userRepository;
        private readonly PasswordHasher _passwordHasher;

        public UserService(IUserRepository userRepository, PasswordHasher passwordHasher)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
        }

        public async Task<User> UpdateUserInfoAsync(int userId, UpdateinfoDto updateInformation)
        {
           
            var user = await _userRepository.getByIdAsync(userId);

            if (user == null) throw new Exception("user not found");

            user.Name = updateInformation.Name ?? user.Name ;
            user.Email = updateInformation.Email ?? user.Email ;

            if (!string.IsNullOrEmpty(updateInformation.Password) && updateInformation.Password == updateInformation.ConfirmPassword)
            {
                user.PasswordHash = _passwordHasher.HashPassword(updateInformation.Password);
            }



            await _userRepository.UpdateAsync(user);
            return user;

        }


        public async Task<User> GetByIdAsync(int userId)
        {
            return await _userRepository.getByIdAsync(userId);
        }

       public async Task<List<AllUsersDto>> GetAllUsersAsync(int pageNumber, int pageSize)
        {
            var users = await _userRepository.GetAllAsync();

            return users
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .Select(u => new AllUsersDto
                {
                    Id = u.Id,
                    Name = u.Name,
                    Email = u.Email,
                    Role = u.Role.ToString()
                })
                .ToList();


        }
    }
}
