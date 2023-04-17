using MKTListNet.Domain.Entities;
using System.Linq.Expressions;

namespace MKTListNet.Domain.Interface.Services
{
    public interface IEmailService : IDisposable
    {
        Task<Email?> GetByIdAsync(Guid id);

        Email? Add(Email email);

        int AddBulk(IList<string> emailbulk);

        Task<IEnumerable<Email>> GetAllAsync();

        IEnumerable<Email?> Find(Expression<Func<Email, bool>> predicate);

        Email Updeate(Email email);

        void Remove(Guid id);

        int SaveChanges();

        Email? GetByEmail(string email);
    }
}
