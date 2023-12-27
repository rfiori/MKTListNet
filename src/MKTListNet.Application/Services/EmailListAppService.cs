using AutoMapper;
using MKTListNet.Application.AppViewModel;
using MKTListNet.Application.Interface;
using MKTListNet.Domain.Entities;
using MKTListNet.Domain.Interface.Services;

namespace MKTListNet.Application.Services
{
    public class EmailListAppService : IEmailListAppService
    {
        private readonly IMapper _mapper;
        private readonly IEmailListService _emailListService;

        //----------------------------------------------------------//

        public EmailListAppService(IMapper mapper, IEmailListService emailListService)
        {
            _mapper = mapper;
            _emailListService = emailListService;
        }

        //----------------------------------------------------------//

        public int Add(EmailListViewModel emailList)
        {
            var emaillist = _mapper.Map<EmailList>(emailList);
            return _emailListService.Add(emaillist);
        }

        public async Task<IEnumerable<EmailListViewModel>?> GetAllAsync()
        {
            return _mapper.Map<IEnumerable<EmailListViewModel>?>(await _emailListService.GetAllAsync());
        }

        public async Task<EmailListViewModel?> GetByIdAsync(int id)
        {
            return _mapper.Map<EmailListViewModel>(await _emailListService.GetByIdAsync(id));
        }

        public IEnumerable<EmailListViewModel>? GetByListName(string listName)
        {
            return _mapper.Map<IEnumerable<EmailListViewModel>?>(_emailListService.GetByListName(listName));
        }

        public async Task<IEnumerable<EmailListViewModel>?> GetEmailsAsync(EmailListViewModel emailLstVM, string? filter)
        {
            return _mapper.Map<IEnumerable<EmailListViewModel>>(
                await _emailListService.GetEmailsAsync(
                        _mapper.Map<EmailList>(emailLstVM),
                        filter)
                );
        }

        public int Remove(int id)
        {
            return _emailListService.Remove(id);
        }

        public EmailListViewModel? Update(EmailListViewModel emailList)
        {
            var emailListRet = _emailListService.Update(_mapper.Map<EmailList>(emailList));
            var retEL = _mapper.Map<EmailListViewModel?>(emailListRet);
            return retEL!;
        }


        public void Dispose()
        {
            _emailListService.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
