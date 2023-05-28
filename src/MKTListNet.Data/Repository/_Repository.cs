using Microsoft.EntityFrameworkCore;
using MKTListNet.Domain.Interface.Repository;
using System.Linq.Expressions;

namespace MKTListNet.Infra.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly MKTListNetContext _DBContext;
        protected readonly DbSet<TEntity> _DbSet;

        //----------------------------------------------------------//

        public Repository(MKTListNetContext dBContext)
        {
            _DBContext = dBContext;
            _DbSet = _DBContext.Set<TEntity>();
        }

        //----------------------------------------------------------//

        public virtual async Task<TEntity?> GetByIdAsync(Guid id)
        {
            return await _DbSet.FindAsync(id);
        }

        public async Task<TEntity?> GetByIdAsync(int id)
        {
            return await _DbSet.FindAsync(id);
        }

        public virtual int Add(TEntity obj)
        {
            var objRet = _DbSet.Add(obj).Entity;
            return SaveChanges();
        }

        public async Task<IPagingResult<TEntity>?> GetAllPagingAsync(int? pageSize, int? page)
        {
            var ret = await GetAllAsync();
            return PagingData(ret, pageSize.Value, page.Value)!;
        }

        public async Task<IEnumerable<TEntity>?> GetAllAsync()
        {
            return await _DbSet.AsNoTracking().ToListAsync();
        }

        public IPagingResult<TEntity>? FindPaging(Expression<Func<TEntity, bool>> predicate, int? pageSize = 50, int? page = 1)
        {
            var ret = Find(predicate);
            return PagingData(ret, pageSize.Value, page.Value);
        }

        public IEnumerable<TEntity>? Find(Expression<Func<TEntity, bool>> predicate)
        {
            return _DbSet.AsNoTracking<TEntity>().Where(predicate).ToList();
        }

        private static IPagingResult<TEntity>? PagingData(IEnumerable<TEntity>? itemsPaging, int pageSize = 30, int page = 1)
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

        public TEntity? Update(TEntity obj)
        {
            if (obj == null)
                return null;

            var entry = _DBContext.Entry(obj);
            _DbSet.Attach(obj);
            entry.State = EntityState.Modified;
            
            SaveChanges();
            return obj;
        }

        public int Remove(Guid id)
        {
            var obj = GetByIdAsync(id)?.Result;
            if (obj != null)
                _DbSet.Remove(obj);

            return SaveChanges();
        }

        public int Remove(int id)
        {
            var obj = GetByIdAsync(id)?.Result;
            if (obj != null)
                _DbSet.Remove(obj);

            return SaveChanges();
        }

        public int SaveChanges()
        {
            return _DBContext.SaveChanges();
        }

        public void Dispose()
        {
            _DBContext.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
