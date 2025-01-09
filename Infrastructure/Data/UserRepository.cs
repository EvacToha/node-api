using Microsoft.EntityFrameworkCore;
using NodeApl.API.Domain.Entities;
using NodeApl.API.Domain.Interfaces;

namespace NodeApl.API.Infrastructure.Data;

public class UserRepository(AppDbContext dbContext) : Repository<User>(dbContext), IUserRepository
{

    public async Task<User?> GetUserByLoginAsync(string username)
    {
        return await dbContext.Users.FirstOrDefaultAsync(u => u.Login == username);
    }
}