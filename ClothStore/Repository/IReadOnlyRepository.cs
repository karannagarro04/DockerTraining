using System;

namespace ClothStore.Repository;

public interface IReadOnlyRepository<T> where T : class
{
    Task<T> GetById(int id);
    Task<IEnumerable<T>> GetAll();
}
