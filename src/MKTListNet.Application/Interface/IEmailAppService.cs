using MKTListNet.Application.ViewModel;
using MKTListNet.Domain.Interface.Repository;

namespace MKTListNet.Application.Interface
{
    public interface IEmailAppService : IDisposable
    {
        Task<EmailViewModel?> GetByIdAsync(Guid id);

        int Add(EmailViewModel emailVM);

        Task<int> AddBulkAsync(IList<string> emailbulk, int? listEmailId);

        Task<IPagingResult<EmailViewModel>?> GetAllPagingAsync(int pageSize = 50, int page = 1);

        Task<IEnumerable<EmailViewModel>?> GetAllAsync();

        IPagingResult<EmailViewModel>? GetEmails(string ContainsEmail, int pageSize = 100, int page = 1);

        EmailViewModel Updeate(EmailViewModel emailVM);

        EmailViewModel? GetByEmail(string email);

        int Remove(Guid id);
    }
}
