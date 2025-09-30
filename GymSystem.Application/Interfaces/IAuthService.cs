using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GymSystem.Application.DTOs.AuthDtos;

namespace GymSystem.Application.Interfaces
{
    public  interface IAuthService
    {

        Task<AuthResponceDto> LogInAsync(LoginDto loginDto);

        Task<AuthResponceDto> Registration(RegisterDto registerDto);

        Task<bool> EmailExistsAsync(string email);


    }
}
