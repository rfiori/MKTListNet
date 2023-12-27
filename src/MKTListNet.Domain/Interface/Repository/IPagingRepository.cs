using System.Linq.Expressions;

namespace MKTListNet.Domain.Interface.Repository
{
    public interface IPagingRepository<TEntity> where TEntity : class
    {
        IPagingResult<TEntity>? PagingData(IEnumerable<TEntity>? itemsPaging, int pageSize = 30, int page = 1);

        IPagingResult<TEntity>? PagingData(dynamic dbSet, int pageSize = 30, int page = 1, Expression<Func<TEntity, bool>>? predicate = null);
    }
}
