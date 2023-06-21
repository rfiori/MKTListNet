using MKTListNet.Application.ViewModel;
using MKTListNet.Domain.Entities;

namespace MKTListNet.Application.Interface
{
    public interface IEmailListAppService : IDisposable
    {
        Task<EmailListViewModel?> GetByIdAsync(int id);

        int Add(EmailListViewModel emaillist);

        //Task<IPagingResult<EmailList>?> GetAllPagingAsync(int pageSize = 50, int page = 1);

        Task<IEnumerable<EmailListViewModel>?> GetAllAsync();

        //IPagingResult<EmailList>? GeByName(string containsListName, int pageSize = 100, int page = 1);

        IEnumerable<EmailListViewModel>? GetByListName(string listName);

        EmailListViewModel? Update(EmailListViewModel emailList);

        int Remove(int id);
    }
}
