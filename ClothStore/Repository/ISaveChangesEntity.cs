using System;

namespace ClothStore.Repository;

public interface ISaveChangesEntity
{
    Task<bool> SaveChanges();
}
