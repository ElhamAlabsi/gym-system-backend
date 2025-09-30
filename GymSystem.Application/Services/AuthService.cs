using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GymSystem.Application.DTOs.AuthDtos;
using GymSystem.Application.Interfaces;
using GymSystem.Domain.Entities;
using GymSystem.Domain.Enums;

namespace GymSystem.Application.Services
{
    public class AuthService : IAuthService
    {

        private readonly IUserRepository _userRepository;
        private readonly IJwtService _jwtService;

        public AuthService(IUserRepository userRepository , IJwtService jwtService )
        {
            _userRepository =userRepository;
            _jwtService =jwtService;    

        }

   
        public async Task<AuthResponceDto> LogInAsync(LoginDto loginDto)
        {

            var user = await _userRepository.getByEmailAsync(loginDto.Email);
            if (user == null) return null;

            if (user.PasswordHash != loginDto.Password)
                return null;


            var token = _jwtService.GenerateToken(user);

            return new AuthResponceDto
            {
                Token = token,
                Name = user.Name,

                Email = user.Email,
                ExpiresAt = DateTime.UtcNow,
            };


        }

        public async Task<AuthResponceDto> Registration(RegisterDto registerDto)
        {
            if (await _userRepository.EmailExistsAsync(registerDto.Email))
                return null;

            var user = new User
            {
                Name = registerDto.Name,
                Email = registerDto.Email,
                PasswordHash = registerDto.Password,
                Role = UserRole.Member,
                CreatedAt = DateTime.UtcNow,
                IsActive = true
            };

            var token = _jwtService.GenerateToken(user);
            await _userRepository.AddAsync(user);

            return new AuthResponceDto
            {
                Token = token,
                Name = user.Name,
                Email = user.Email,
                ExpiresAt = DateTime.UtcNow,

            };

        }
        public async Task<bool> EmailExistsAsync(string email)
        {
            return await _userRepository.EmailExistsAsync(email);
        }
    }
}
