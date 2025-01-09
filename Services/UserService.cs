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
    
    public async Task<RegisterResponse> RegisterAsync(UserRegisterDto userDto)
    {
        
        var existedUser = await userRepository.GetUserByLoginAsync(userDto.Login);
        if (existedUser != null)
        {
            return new RegisterResponse{Success = false, Message = "Пользователь уже зарегестрирован." };
        }
        
        var hashedPassword = _passwordHasher.HashPassword(null!, userDto.Password);
        try
        {
            await userRepository.AddAsync(new User
            {
                Login = userDto.Login,
                FullName = userDto.FullName,
                PasswordHash = hashedPassword
            });
            var result = await userRepository.SaveChangesAsync();
            
            if (result > 0)
            {
                return new RegisterResponse{Success = true, Message = "Пользователь успешно зарегистрирован."};
            }
            
            return new RegisterResponse{Success = false, Message = "Ошибка при регистрации пользователя. Попробуйте позже."};
            
            
        }
        catch (Exception ex)
        {
            return new RegisterResponse{Success = false, Message = "Ошибка при регистрации пользователя." };
        }
        
    }

    public async Task<LoginResponse> LoginAsync(UserLoginDto userDto)
    {
        var user = await userRepository.GetUserByLoginAsync(userDto.Login);
        if (user == null)
        {
            return new LoginResponse{Success = false, Message = "Пользователя не существует." };
        }
        
        var result = _passwordHasher.VerifyHashedPassword(null!, user.PasswordHash, userDto.Password);
        if (result == PasswordVerificationResult.Failed)
        {
            return new LoginResponse{Success = false, Message = "Неверный пароль." };
        }
        
        var token = GenerateJwtToken(user);

        return new LoginResponse{Success = true, Message = "Успешный вход.", Token = token };
        
    }
    
    private string GenerateJwtToken(User user)
    {
        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.Login),
            new Claim(ClaimTypes.Name, user.FullName)
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