namespace MKTListNet.Domain.Interfaces.Repository
{
    public interface IPagingResult<TEntity> where TEntity : class
    {
        IEnumerable<TEntity>? Items { get; }

        int PageNumber { get; }

        int PageSize { get; }

        int TotalItems { get; }

        int TotalPages { get; }
    }
}
