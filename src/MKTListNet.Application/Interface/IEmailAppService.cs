using MKTListNet.Application.ViewModel;
using MKTListNet.Domain.Entities;
using System.Linq.Expressions;

namespace MKTListNet.Application.Interface
{
    public interface IEmailAppService : IDisposable
    {
        Task<EmailViewModel?> GetByIdAsync(Guid id);

        EmailViewModel Add(EmailViewModel emailVM);

        int AddBulk(IList<string> emailbulk);

        Task<IEnumerable<EmailViewModel>> GetAllAsync();

        IEnumerable<EmailViewModel?> Find(Expression<Func<EmailViewModel, bool>> predicate);

        EmailViewModel Updeate(EmailViewModel emailVM);

        void Remove(Guid id);

        int SaveChanges();

        EmailViewModel? GetByEmail(string email);
    }
}
