namespace NodeApl.API.Domain.Interfaces;

public interface IRepository<T> where T: class
{
    Task<T?> GetByIdAsync(int id);
    Task<IEnumerable<T>> GetAllAsync();
    Task<T> AddAsync(T entity);
    Task<int> SaveChangesAsync();
    void Delete(T entity);
    void Update(T entity);
}