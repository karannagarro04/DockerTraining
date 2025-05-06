using System;
using System.Threading.Tasks;
using ClothStore.Models;
using Microsoft.EntityFrameworkCore;

namespace ClothStore.Repository;

public class Repository<T> : IRepository<T>, IReadOnlyRepository<T>, IWriteOnlyRepository<T> where T : class
{
    private readonly RetailDistributionContext _context;
    private readonly DbSet<T> _dbSet;
    public Repository(RetailDistributionContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _dbSet = _context.Set<T>() ?? throw new ArgumentNullException(nameof(_dbSet));
    }

    public async Task Add(T entity)
    {
        await _dbSet.AddAsync(entity);
    }

    public void Update(T entity)
    {
        _dbSet.Update(entity);
    }

    public void Delete(T entity)
    {
       _dbSet.Remove(entity);
    }

    public async Task<T> GetById(int id)
    {
        return await _dbSet.FindAsync(id) ?? throw new InvalidOperationException($"Entity of type {typeof(T).Name} with ID {id} not found.");
    }

    public async Task<IEnumerable<T>> GetAll()
    {
        return await _dbSet.ToListAsync();
    }

    
    public async Task<bool> SaveChanges()
    {
        // Implementation for saving changes to the database
        try
        {
            return await _context.SaveChangesAsync() > 0;
        }
        catch (Exception ex)
        {
            // Handle exceptions as needed
            throw new Exception("An error occurred while saving changes.", ex);
        }
    }
}
