using System;

namespace ClothStore.Repository;

public interface IRepository<T> : IReadOnlyRepository<T>, IWriteOnlyRepository<T> where T : class
{
    // Here you can add any additional methods that are common to both read and write operations
    
}
