using NodeApl.API.Domain.Entities;

namespace NodeApl.API.Domain.Interfaces;

public interface IUserRepository
{
    Task AddUserAsync(User user);
    Task<User?> GetUserByUsernameAsync(string username);
}