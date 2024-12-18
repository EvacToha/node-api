using Microsoft.EntityFrameworkCore;
using NodeApl.API.Domain.Entities;
using NodeApl.API.Domain.Interfaces;

namespace NodeApl.API.Infrastructure.Data;

public class UserRepository(AppDbContext dbContext) : IUserRepository
{
    public async Task AddUserAsync(User user)
    {
        await dbContext.Users.AddAsync(user);
        await dbContext.SaveChangesAsync();
    }

    public async Task<User?> GetUserByUsernameAsync(string username)
    {
        return await dbContext.Users.FirstOrDefaultAsync(u => u.Username == username);
    }
}