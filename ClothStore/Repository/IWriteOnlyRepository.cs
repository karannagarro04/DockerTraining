using System;

namespace ClothStore.Repository;

public interface IWriteOnlyRepository<T> : IAddOnlyRepository<T>, IUpdateOnlyRepository<T>, IDeleteOnlyRepository<T>,ISaveChangesEntity where T : class
{
    // This interface combines the functionalities of adding, updating, deleting, and saving changes for a specific entity type T.
    // It inherits from IAddOnlyRepository<T>, IUpdateOnlyRepository<T>, IDeleteOnlyRepository<T>, and ISaveChangesEntity.
    // This allows for a more streamlined approach to managing entities in the repository pattern.
    // By implementing this interface, a class can handle all write operations for the entity type T.
}
