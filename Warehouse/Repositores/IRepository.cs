﻿using WarehouseApp.Entities;

namespace WarehouseApp.Repositores
{
    public interface IRepository<T> : IReadRepository<T>, IWriteRepository<T> 
        where T : class, IEntity
    {
    }
}
