﻿using System.Linq.Expressions;

namespace MKTListNet.Domain.Interface.Repository
{
    public interface IRepository<TEntity> : IDisposable where TEntity : class
    {
        Task<TEntity?> GetByIdAsync(Guid id);

        Task<TEntity?> GetByIdAsync(int id);

        int Add(TEntity obj);

        Task<IEnumerable<TEntity>> GetAllAsync();

        IEnumerable<TEntity?> Find(Expression<Func<TEntity, bool>> predicate);

        TEntity Updeate(TEntity obj);

        void Remove(Guid id);

        void Remove(int id);

        int SaveChanges();
    }
}
