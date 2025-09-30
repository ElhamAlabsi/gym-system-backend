using GymSystem.Application.DTOs.AuthDtos;
using GymSystem.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GymSystem.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase  
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

       
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            if (!ModelState.IsValid)  
                return BadRequest(ModelState);

            var result = await _authService.LogInAsync(loginDto);  

            if (result == null)
                return Unauthorized(new { message = "Email or password is incorrect" });

            return Ok(result);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
        {
            if (!ModelState.IsValid)  
                return BadRequest(ModelState);

            if (registerDto.Password != registerDto.ConfirmPassword)
                return BadRequest(new { message = "Passwords do not match" });

            var result = await _authService.Registration(registerDto); 

            if (result == null)
                return BadRequest(new { message = "Email already exists" });

            return Ok(result);
        }
    }
}