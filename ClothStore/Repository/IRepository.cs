using System;

namespace ClothStore.Repository;

public interface IRepository<T> where T : class
{
    // Define methods for CRUD operations
    Task<bool> SaveChanges();
}
