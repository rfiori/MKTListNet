using Microsoft.EntityFrameworkCore;
using MKTListNet.CrossCutting.Shared.Interfaces;
using System.Linq.Expressions;

namespace MKTListNet.CrossCutting.Shared.Services
{
	public class PagingRepository<TEntity> : IPagingRepository<TEntity> where TEntity : class
    {
        public IPagingResult<TEntity>? PagingData(IEnumerable<TEntity>? itemsPaging, int pageSize = 30, int page = 1)
        {
            if (itemsPaging == null || itemsPaging?.Count() < 1)
                return null;

            int TotalItems = itemsPaging!.Count();
            int TotalPages = (int)Math.Ceiling((double)TotalItems / pageSize);

            // Garantir que a página atual não exceda o número total de páginas
            page = Math.Max(1, Math.Min(page, TotalPages));

            // Calcular o índice de início e quantidade de itens a serem carregados
            int StartIndex = (page - 1) * pageSize;
            int ItemsToLoad = Math.Min(pageSize, TotalItems - StartIndex);

            var ret2 = itemsPaging!.Skip(StartIndex).Take(ItemsToLoad);

            // Criar um objeto de paginação customizado
            return new PagingResult<TEntity>(ret2, page, pageSize, TotalItems, TotalPages);
        }

        public IPagingResult<TEntity>? PagingData(dynamic dbSet, int pageSize = 100, int page = 1, Expression<Func<TEntity, bool>>? predicate = null)
        {
            var DbSetObj = dbSet as DbSet<TEntity>;

            int skip = (page - 1) * pageSize;

            IQueryable<TEntity>? ret;

            if (predicate != null)
                ret = DbSetObj?.Where(predicate).Skip(skip).Take(pageSize);
            else
                ret = DbSetObj?.Skip(skip).Take(pageSize);

            if (ret != null)
                return null;

            int totalItems = ret!.Count();
            int totalPages = (int)Math.Ceiling((double)totalItems / pageSize);

            // Criar um objeto de paginação customizado
            return new PagingResult<TEntity>(ret!.ToList(), page, pageSize, totalItems, totalPages);
        }
    }
}
