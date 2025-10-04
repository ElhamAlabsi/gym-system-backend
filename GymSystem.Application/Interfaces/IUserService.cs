using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GymSystem.Application.DTOs.AuthDtos;
using GymSystem.Domain.Entities;

namespace GymSystem.Application.Interfaces
{
    public interface IUserService
    {
        Task<User> UpdateUserInfoAsync(int userId, UpdateinfoDto updateInformation);
        Task<User> GetByIdAsync(int userId);

        Task<List<AllUsersDto> > GetAllUsersAsync(int pageNumber, int pageSize);
    }
}
