using GymSystem.Application.DTOs.AuthDtos;
using GymSystem.Application.Interfaces;
using GymSystem.Application.Services;
using GymSystem.Domain.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GymSystem.API.Controllers
{


    [ApiController]
    [Route("api/[controller]")]
    public class ProfileController : Controller
    {

        private readonly IUserService _userService;

        public ProfileController(IUserService userService)
        {
            _userService = userService;
        }

        [Authorize]
        [HttpPut("update")]
        public async Task<IActionResult> UpdateInfo([FromBody] UpdateinfoDto updateInformationDto)
        {
            if(!ModelState.IsValid) 
                return BadRequest(ModelState);


            var userId = int.Parse(User.FindFirst("userId").Value);
            var Updateuser = await _userService.UpdateUserInfoAsync(userId, updateInformationDto);

            return Ok(Updateuser);

        }

        [Authorize(Roles = "Admin")]
        [HttpGet("AllUsers")]
        public async Task<IActionResult> GetAllUsers(int pageNumber = 1 , int pagesize = 10)
        {
            var allusers = await _userService.GetAllUsersAsync(pageNumber , pagesize);

            return Ok(allusers);

        }
        
    }
}
    