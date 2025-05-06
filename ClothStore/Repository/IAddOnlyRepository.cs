using System;

namespace ClothStore.Repository;

public interface IAddOnlyRepository<T> where T : class
{
        Task Add(T entity);
}
