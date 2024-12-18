using Microsoft.AspNetCore.Mvc;
using NodeApl.API.Domain.DTOs;
using NodeApl.API.Domain.Interfaces;

namespace NodeApl.API.Controllers;

public class UserController(IUserService userService) : BaseController
{
    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] UserRegisterDto request)
    {
        var result = await userService.RegisterUserAsync(request);
        if (!result.Success)
        {
            return BadRequest(new {
                result.Message
            });
        }
        
        return Ok(result.Message);
    }
    
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] UserLoginDto request)
    {
        var result = await userService.LoginUserAsync(request);
        if (!result.Success)
        {
            return BadRequest(new {
                result.Message
            });
        }
        
        return Ok(new { result.Token});
    }
    
}