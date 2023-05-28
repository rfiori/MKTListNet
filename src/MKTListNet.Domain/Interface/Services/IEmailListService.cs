using MKTListNet.Domain.Entities;
using MKTListNet.Domain.Interface.Repository;
using System.Linq.Expressions;

namespace MKTListNet.Domain.Interface.Services
{
    public interface IEmailListService : IDisposable
    {
        Task<EmailList?> GetByIdAsync(int id);

        int Add(EmailList email);

        //Task<IPagingResult<EmailList>?> GetAllPagingAsync(int pageSize = 50, int page = 1);

        Task<IEnumerable<EmailList>?> GetAllAsync();

        //IPagingResult<EmailList>? GeByName(string containsListName, int pageSize = 100, int page = 1);

        IEnumerable<EmailList>? GetByListName(string listName);

        IEnumerable<EmailList>? Find(Expression<Func<EmailList, bool>> predicate);

        EmailList? Update(EmailList email);

        void Remove(int id);

        int SaveChanges();
    }
}
