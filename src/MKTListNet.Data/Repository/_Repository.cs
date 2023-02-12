using Microsoft.EntityFrameworkCore;
using MKTListNet.Domain.Interface;
using MKTListNet.Infra;
using System.Linq.Expressions;

namespace MKTListNet.Data.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly MKTListNetContext _DBContext;

        protected readonly DbSet<TEntity> _DbSet;


        public Repository(MKTListNetContext dBContext)
        {
            _DBContext = dBContext;
            _DbSet = _DBContext.Set<TEntity>();
        }



        public virtual async Task<TEntity?> GetByIdAsync(Guid id)
        {
            return await _DbSet.FindAsync(id);
        }

        public async Task<TEntity?> GetByIdAsync(int id)
        {
            return await _DbSet.FindAsync(id);
        }

        public virtual TEntity Add(TEntity obj)
        {
            var objRet = _DbSet.Add(obj).Entity;
            SaveChanges();
            return objRet;
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _DbSet.AsNoTracking().ToListAsync();
        }

        public IEnumerable<TEntity?> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return _DbSet.AsNoTracking<TEntity>().Where(predicate);
        }

        public TEntity Updeate(TEntity obj)
        {
            var entry = _DBContext.Entry(obj);
            _DbSet.Attach(obj);
            entry.State = EntityState.Modified;
            SaveChanges();
            return obj;
        }

        public void Remove(Guid id)
        {
            var obj = GetByIdAsync(id)?.Result;
            if (obj != null)
                _DbSet.Remove(obj);
        }

        public void Remove(int id)
        {
            var obj = GetByIdAsync(id)?.Result;
            if (obj != null)
                _DbSet.Remove(obj);
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
