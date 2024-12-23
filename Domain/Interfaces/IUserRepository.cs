using NodeApl.API.Domain.Entities;

namespace NodeApl.API.Domain.Interfaces;

public interface IUserRepository : IRepository<User>
{
    Task<User?> GetUserByUsernameAsync(string username);
}