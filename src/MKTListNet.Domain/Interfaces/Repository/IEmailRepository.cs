using MKTListNet.CrossCutting.Shared.Interfaces;
using MKTListNet.Domain.Entities;

namespace MKTListNet.Domain.Interfaces.Repository
{
    public interface IEmailRepository : IRepository<Email>, IPagingRepository<Email>
    {
        Email? GetByEmail(string email);

        Task<ICollection<EmailList>?> GetEmailListAsync(Email email);
    }
}
