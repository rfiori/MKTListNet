using Microsoft.EntityFrameworkCore;
using MKTListNet.Domain.Entities;
using MKTListNet.Domain.Interface.Repository;
using System.Linq.Expressions;

namespace MKTListNet.Infra.Repository
{
    public class EmailRepository : Repository<Email>, IEmailRepository
    {
        private readonly MKTListNetContext _Contex;
        private readonly DbSet<Email> DbSet;

        public EmailRepository(MKTListNetContext dBContext) : base(dBContext)
        {
            _Contex = dBContext;
            DbSet = _Contex.Set<Email>();
        }


        public async Task<int> AddBulkAsync(IList<Email> lstEmail)
        {
            if (lstEmail == null || lstEmail.Count == 0)
                return 0;

            foreach (var item in lstEmail)
                await DbSet.AddAsync(item);

            return await _Contex.SaveChangesAsync();
        }

        public Email? GetByEmail(string email)
        {
            return Find(e => e.EmailAddress == email)?.FirstOrDefault();
        }
    }
}
