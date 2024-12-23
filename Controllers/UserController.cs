using Microsoft.AspNetCore.Mvc;
using NodeApl.API.Domain.DTOs;
using NodeApl.API.Domain.Interfaces;
using NodeApl.API.Domain.Responses;

namespace NodeApl.API.Controllers;

public class UserController(IUserService userService) : BaseController
{
    /// <summary>
    /// Регистрация
    /// </summary>
    /// <remarks>
    /// Пример запроса:
    ///
    ///     POST /api/User/register
    ///     {
    ///        "login": "lil_evac", 
    ///        "password": "zaqwsxcderfvbtyhn",
    ///        "fullName": "Дима"
    ///     }
    ///
    /// </remarks>
    /// <param name="model">Данные пользователя</param>
    /// <returns></returns>
    /// <response code="200">Успешное выполнение</response>
    /// <response code="400">Ошибка API</response>
    
    [HttpPost("register")]
    [ProducesResponseType(typeof(RegisterResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(RegisterResponse),StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Register([FromBody] UserRegisterDto model)
    {
        var result = await userService.RegisterAsync(model);
        if (!result.Success)
        {
            return BadRequest(new {
                result.Message
            });
        }
        
        return Ok();
    }
    
   
    /// <summary>
    /// Вход в аккаунт
    /// </summary>
    /// <remarks>
    /// Пример запроса:
    ///
    ///     POST /api/User/login
    ///     {
    ///        "login": "lil_evac", 
    ///        "password": "zaqwsxcderfvbtyhn"
    ///     }
    ///
    /// </remarks>
    /// <param name="model">Данные пользователя</param>
    /// <returns></returns>
    /// <response code="200">Успешное выполнение</response>
    /// <response code="400">Ошибка API</response>
    
    [ProducesResponseType(typeof(LoginResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(LoginResponse),StatusCodes.Status400BadRequest)]
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] UserLoginDto model)
    {
        var result = await userService.LoginAsync(model);
        if (!result.Success)
        {
            return BadRequest(new {
                result.Message
            });
        }
        
        return Ok(new { result.Token});
    }
    
}