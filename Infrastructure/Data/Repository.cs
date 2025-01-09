using Microsoft.EntityFrameworkCore;
using NodeApl.API.Domain.Interfaces;

namespace NodeApl.API.Infrastructure.Data;

public class Repository<T> : IRepository<T> where T : class 
{
    private readonly AppDbContext _dbContext;
    private readonly DbSet<T> _dbSet;

    public Repository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
        _dbSet = _dbContext.Set<T>();
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _dbSet.ToListAsync();
    }

    public async Task<T?> GetByIdAsync(int id)
    {
        return await _dbSet.FindAsync(id);
    }

    public async Task<T> AddAsync(T entity)
    {
        var entry = await _dbSet.AddAsync(entity);
        return entry.Entity;
    }

    public void Delete(T entity)
    {
        _dbSet.Entry(entity).State = EntityState.Deleted;
    }

    public void Update(T entity)
    {
        _dbSet.Entry(entity).State = EntityState.Modified;
    }
    public async Task<int> SaveChangesAsync()
    {
        return await _dbContext.SaveChangesAsync();
    }

    

    
}