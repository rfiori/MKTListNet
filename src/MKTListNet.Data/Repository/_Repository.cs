using Microsoft.EntityFrameworkCore;
using MKTListNet.Domain.Interface.Repository;
using System.Linq.Expressions;

namespace MKTListNet.Infra.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly MKTListNetContext _DBContext;
        protected readonly DbSet<TEntity> _DbSet;
        protected readonly IPagingRepository<TEntity> _PagingRepository;

        //----------------------------------------------------------//

        public Repository(MKTListNetContext dBContext, IPagingRepository<TEntity> pagingRepository)
        {
            _DBContext = dBContext;
            _DbSet = _DBContext.Set<TEntity>();
            _PagingRepository = pagingRepository;
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

        public async Task<int> AddBulkAsync(ICollection<TEntity> lstTEntity)
        {
            if (lstTEntity == null || lstTEntity.Count == 0)
                return 0;

            foreach (var item in lstTEntity)
                await _DbSet.AddAsync(item);

            return await _DBContext.SaveChangesAsync();
        }

        public Task<IPagingResult<TEntity>?> GetAllPagingAsync(int? pageSize = 100, int? page = 1)
        {
            //var ret = await GetAllAsync();
            return Task.FromResult(_PagingRepository.PagingData(_DbSet, pageSize!.Value, page!.Value));
        }

        [Obsolete("Use new method GetAllPagingAsync()")]
        public async Task<IEnumerable<TEntity>?> GetAllAsync()
        {
            return await _DbSet.ToListAsync();
        }

        public IPagingResult<TEntity>? FindPaging(Expression<Func<TEntity, bool>> predicate, int pageSize = 100, int page = 1)
        {
            return _PagingRepository.PagingData(_DbSet, pageSize, page, predicate);
            //var ret = Find(predicate);
            //return _PagingRepository.PagingData(ret, pageSize!.Value, page!.Value);
        }

        public IEnumerable<TEntity>? Find(Expression<Func<TEntity, bool>> predicate)
        {
            return _DbSet.Where(predicate).ToList();
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
