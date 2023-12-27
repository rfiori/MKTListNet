using System.Linq.Expressions;

namespace MKTListNet.Domain.Interfaces.Repository
{
    public interface IRepository<TEntity> : IDisposable where TEntity : class
    {
        Task<TEntity?> GetByIdAsync(dynamic id);

        int Add(TEntity obj);

        Task<int> AddBulkAsync(ICollection<TEntity> lstTEntity);

        Task<IPagingResult<TEntity>?> GetAllPagingAsync(int? pageSize, int? page);

        [Obsolete("Use new method GetAllPagingAsync()")]
        Task<IEnumerable<TEntity>?> GetAllAsync();

        IPagingResult<TEntity>? FindPaging(Expression<Func<TEntity, bool>> predicate, int pageSize = 50, int page = 1);

        IEnumerable<TEntity>? Find(Expression<Func<TEntity, bool>> predicate);

        TEntity? Update(TEntity obj);

        int Remove(dynamic id);

        int SaveChanges();
    }
}
