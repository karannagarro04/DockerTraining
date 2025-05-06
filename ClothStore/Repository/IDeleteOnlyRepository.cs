using System;

namespace ClothStore.Repository;

public interface IDeleteOnlyRepository<T> where T : class
{
      void Delete(T entity);
}
