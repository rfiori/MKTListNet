using MKTListNet.Domain.Entities;

namespace MKTListNet.Domain.Interface.Services
{
    public interface IEmailEmailListService : IDisposable
    {
        IEnumerable<EmailEmailList>? GetByEmailId(Guid emailId);

        IEnumerable<EmailEmailList>? GetByEmailListId(int emailListId);

        int Add(Guid emailId, int emailListId);

        Task<int> AddBulkAsync(IList<Guid> lstEmail, int emailListId);

        //Task<IPagingResult<EmailEmailList>?> GetAllPagingAsync(int pageSize = 50, int page = 1);

        EmailEmailList? Update(EmailEmailList emailEmlLst);

        int RemoveEmailId(Guid EmailId);

        int RemoveEmailListId(int emailEmlLstId);

        int SaveChanges();
    }
}
