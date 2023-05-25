namespace MKTListNet.Domain.Interface.Repository
{
    public interface IPagingResult<TEntity> where TEntity : class
    {
        public IEnumerable<TEntity>? Items { get; }

        public int PageNumber { get; }

        public int PageSize { get; }

        public int TotalItems { get; }

        public int TotalPages { get; }
    }
}
