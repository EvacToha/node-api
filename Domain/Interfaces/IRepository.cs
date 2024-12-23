﻿namespace NodeApl.API.Domain.Interfaces;

public interface IRepository<T> where T: class
{
    Task<IEnumerable<T>> GetAllAsync();
    Task<T?> GetByIdAsync(int id);
    Task AddAsync(T entity);
    Task<int> SaveChangesAsync();
}