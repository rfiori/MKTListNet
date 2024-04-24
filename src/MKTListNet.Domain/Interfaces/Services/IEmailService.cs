using MKTListNet.CrossCutting.Shared.Interfaces;
using MKTListNet.Domain.Entities;
using MKTListNet.Domain.Interfaces.Repository;
using System.Linq.Expressions;

namespace MKTListNet.Domain.Interfaces.Services
{
    public interface IEmailService : IDisposable
    {
        Task<Email?> GetByIdAsync(Guid id);

        int Add(Email email);

        Task<int> AddBulkAsync(IList<string> lstEmail, int? listEmailId);

        Task<IPagingResult<Email>?> GetAllPagingAsync(int pageSize = 50, int page = 1);

        Task<IEnumerable<Email>?> GetAllAsync();

        IPagingResult<Email>? GetEmails(string containsEmail, int emailListId, int pageSize = 100, int page = 1);

        Task<IEnumerable<EmailList>?> GetEmailListAsync(Email email);

        IEnumerable<Email>? Find(Expression<Func<Email, bool>> predicate);

        Email? Update(Email email);

        int Remove(Guid id);

        int SaveChanges();

        Email? GetByEmail(string email);
    }
}
