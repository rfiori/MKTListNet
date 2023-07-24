using MKTListNet.Application.ViewModwl;

namespace MKTListNet.Application.Interface
{
    public interface IEmailEmailListAppServive
    {
        IEnumerable<EmailEmailListViewModel>? GetByEmailId(Guid emailId);

        IEnumerable<EmailEmailListViewModel>? GetByEmailListId(int emailListId);

        int Add(Guid emailId, int emailListId);

        Task<int> AddBulkAsync(IList<Guid> lstEmail, int emailListId);

        //Task<IPagingResult<EmailEmailListViewModel>?> GetAllPagingAsync(int pageSize = 50, int page = 1);

        EmailEmailListViewModel? Update(EmailEmailListViewModel emailEmlLst);

        int RemoveEmailId(Guid EmailId);

        int RemoveEmailListId(int emailEmlLstId);

        int SaveChanges();
    }
}
