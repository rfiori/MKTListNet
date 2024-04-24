using MKTListNet.CrossCutting.Shared.Interfaces;

namespace MKTListNet.CrossCutting.Shared.Services
{
    public class PagingResult<TEntity> : IPagingResult<TEntity> where TEntity : class
    {
        public IEnumerable<TEntity>? Items { get; }

        public int PageNumber { get; }

        public int PageSize { get; }

        public int TotalItems { get; }

        public int TotalPages { get; }


        //public PagingResult()
        //{

        //}

        public PagingResult(IEnumerable<TEntity> items, int pageNumber, int pageSize, int totalItems, int totalPages)
        {
            Items = items;
            PageNumber = pageNumber;
            PageSize = pageSize;
            TotalItems = totalItems;
            TotalPages = totalPages;
        }
    }
}
