namespace MKTListNet.Domain.Interface.Repository
{
    public interface IPagingRepository<TEntity> where TEntity : class
    {
        IPagingResult<TEntity>? PagingData(IEnumerable<TEntity>? itemsPaging, int pageSize = 30, int page = 1);
    }
}
