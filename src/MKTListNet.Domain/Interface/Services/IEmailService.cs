using MKTListNet.Domain.Entities;
using MKTListNet.Domain.Interface.Repository;
using System.Linq.Expressions;

namespace MKTListNet.Domain.Interface.Services
{
    public interface IEmailService : IDisposable
    {
        Task<Email?> GetByIdAsync(Guid id);

        int Add(Email email);

        Task<int> AddBulkAsync(IList<string> lstEmail);

        Task<IPagingResult<Email>?> GetAllPagingAsync(int pageSize = 50, int page = 1);

        Task<IEnumerable<Email>?> GetAllAsync();

        IPagingResult<Email>? GetEmails(string containsEmail, int pageSize = 100, int page = 1);

        IEnumerable<Email>? Find(Expression<Func<Email, bool>> predicate);

        Email? Update(Email email);

        int Remove(Guid id);

        int SaveChanges();

        Email? GetByEmail(string email);
    }
}
