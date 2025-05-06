using System;

namespace ClothStore.Repository;

public interface IUpdateOnlyRepository<T> where T : class
{
        void Update(T entity);
}
