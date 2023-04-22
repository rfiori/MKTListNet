using MKTListNet.Application.ViewModel;
using System.Linq.Expressions;

namespace MKTListNet.Application.Interface
{
    public interface IEmailAppService : IDisposable
    {
        Task<EmailViewModel?> GetByIdAsync(Guid id);

        int Add(EmailViewModel emailVM);

        Task<int> AddBulkAsync(IList<string> emailbulk);

        Task<IEnumerable<EmailViewModel>> GetAllAsync();

        IEnumerable<EmailViewModel?> Find(Expression<Func<EmailViewModel, bool>> predicate);

        EmailViewModel Updeate(EmailViewModel emailVM);

        void Remove(Guid id);

        int SaveChanges();

        EmailViewModel? GetByEmail(string email);
    }
}
