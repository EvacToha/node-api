using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using NodeApl.API.Domain.DTOs;
using NodeApl.API.Domain.Entities;
using NodeApl.API.Domain.Interfaces;
using NodeApl.API.Domain.Responses;

namespace NodeApl.API.Services;

public class UserService(IUserRepository userRepository, IConfiguration configuration) : IUserService
{
    private readonly PasswordHasher<object> _passwordHasher = new();
    
    public async Task<UserRegisterResponse> RegisterUserAsync(UserRegisterDto userDto)
    {
        var existedUser = await userRepository.GetUserByUsernameAsync(userDto.UserName);
        if (existedUser != null)
        {
            return new UserRegisterResponse{Success = false, Message = "Пользователь уже зарегестрирован." };
        }
        
        var hashedPassword = _passwordHasher.HashPassword(null!, userDto.Password);
        
        await userRepository.AddUserAsync(new User {
            Username = userDto.UserName,
            Name = userDto.Name, 
            PasswordHash = hashedPassword
        });
        
        return new UserRegisterResponse{Success = true, Message = "Пользователь успешно зарегистрирован."};
    }

    public async Task<UserLoginResponse> LoginUserAsync(UserLoginDto userDto)
    {
        var user = await userRepository.GetUserByUsernameAsync(userDto.UserName);
        if (user == null)
        {
            return new UserLoginResponse{Success = false, Message = "Пользователя не существует." };
        }
        
        var result = _passwordHasher.VerifyHashedPassword(null!, user.PasswordHash, userDto.Password);
        if (result == PasswordVerificationResult.Failed)
        {
            return new UserLoginResponse{Success = false, Message = "Неверный пароль." };
        }
        
        var token = GenerateJwtToken(user);

        return new UserLoginResponse{Success = true, Message = "Успешный вход.", Token = token };
        
    }
    
    private string GenerateJwtToken(User user)
    {
        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.Username),
            new Claim(ClaimTypes.Name, user.Name)
        };
    
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: configuration["Jwt:Issuer"],
            audience: configuration["Jwt:Issuer"],
            claims: claims,
            expires: DateTime.Now.AddMinutes(10), 
            signingCredentials: creds
            );
        
        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}