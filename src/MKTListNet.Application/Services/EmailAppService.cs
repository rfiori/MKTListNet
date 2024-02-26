using AutoMapper;
using MKTListNet.Application.AppViewModel;
using MKTListNet.Application.Interface;
using MKTListNet.Domain.Entities;
using MKTListNet.Domain.Interfaces.Repository;
using MKTListNet.Domain.Interfaces.Services;
using MKTListNet.Infra.Repository;

namespace MKTListNet.Application.Services
{
    public class EmailAppService : IEmailAppService
    {
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;

        //----------------------------------------------------------//

        public EmailAppService(IMapper mapper, IEmailService emailService)
        {
            _mapper = mapper;
            _emailService = emailService;
        }

        //----------------------------------------------------------//

        public int Add(EmailViewModel emailVM)
        {
            var email = _mapper.Map<Email>(emailVM);
            return _emailService.Add(email);
        }

        public async Task<int> AddBulkAsync(IList<string> emailbulk, int? listEmailId)
        {
            return await _emailService.AddBulkAsync(emailbulk, listEmailId);
        }

        public IPagingResult<EmailViewModel>? GetEmails(string containsEmail, int emailListId, int pageSize = 50, int page = 1)
        {
            return _mapper.Map<PagingResult<EmailViewModel>?>(_emailService.GetEmails(containsEmail, emailListId, pageSize, page));
        }

        public async Task<IPagingResult<EmailViewModel>?> GetAllPagingAsync(int pageSize = 50, int page = 1)
        {
            return _mapper.Map<PagingResult<EmailViewModel>?>(await _emailService.GetAllPagingAsync(pageSize, page));
        }

        [Obsolete("Use new method GetAllPagingAsync()")]
        public async Task<IEnumerable<EmailViewModel>?> GetAllAsync()
        {
            return _mapper.Map<IEnumerable<EmailViewModel>?>(await _emailService.GetAllAsync());
        }

        public EmailViewModel? GetByEmail(string email)
        {
            return _mapper.Map<EmailViewModel>(_emailService.GetByEmail(email));
        }

        public async Task<EmailViewModel?> GetByIdAsync(Guid id)
        {
            return _mapper.Map<EmailViewModel>(await _emailService.GetByIdAsync(id));
        }

        public async Task<IEnumerable<EmailListViewModel>?> GetEmailListAsync(EmailViewModel emailVM)
        {
            return _mapper.Map<IEnumerable<EmailListViewModel>>(await _emailService.GetEmailListAsync(_mapper.Map<Email>(emailVM)));
        }

        public EmailViewModel Updeate(EmailViewModel retE)
        {
            var emailRet = _emailService.Update(_mapper.Map<Email>(retE));
            //if (emailRet != null)
            //{
            //    _emailService.SaveChanges();
            //}
            retE = _mapper.Map<EmailViewModel>(emailRet);
            return retE;
        }

        public int Remove(Guid id)
        {
            return _emailService.Remove(id);
        }

        public void Dispose()
        {
            _emailService.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
