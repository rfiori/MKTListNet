using MKTListNet.Domain.Entities;

namespace MKTListNet.Domain.Interface.Repository
{
    public interface IEmailListRepository : IRepository<EmailList>
    {
        Task<IEnumerable<Email>?> GetEmailsAsync(EmailList emailLst, string? filter);
    }

}
