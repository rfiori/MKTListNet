using AutoMapper;
using MKTListNet.Application.Interface;
using MKTListNet.Application.ViewModel;
using MKTListNet.Domain.Entities;
using MKTListNet.Domain.Interface.Repository;
using MKTListNet.Domain.Interface.Services;
using MKTListNet.Infra.Repository;
using System.Linq.Expressions;

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

        public async Task<int> AddBulkAsync(IList<string> emailbulk)
        {
            return await _emailService.AddBulkAsync(emailbulk);
        }

        public IPagingResult<EmailViewModel>? GetEmails(string containsEmail, int pageSize = 50, int page = 1)
        {
            return _mapper.Map<PagingResult<EmailViewModel>?>(_emailService.GetEmails(containsEmail, pageSize, page));
        }

        public async Task<IPagingResult<EmailViewModel>?> GetAllPagingAsync(int pageSize = 50, int page = 1)
        {
            return _mapper.Map<PagingResult<EmailViewModel>?>(await _emailService.GetAllPagingAsync(pageSize, page));
        }

        public async Task<IEnumerable<EmailViewModel>> GetAllAsync()
        {
            return _mapper.Map<IEnumerable<EmailViewModel>>(await _emailService.GetAllAsync());
        }

        public EmailViewModel? GetByEmail(string email)
        {
            return _mapper.Map<EmailViewModel>(_emailService.GetByEmail(email));
        }

        public async Task<EmailViewModel?> GetByIdAsync(Guid id)
        {
            return _mapper.Map<EmailViewModel>(await _emailService.GetByIdAsync(id));
        }

        public EmailViewModel Updeate(EmailViewModel emailVM)
        {
            var email = _mapper.Map<Email>(emailVM);
            var emailRet = _emailService.Update(email);
            if (emailRet != null)
            {
                _emailService.SaveChanges();
            }
            emailVM = _mapper.Map<EmailViewModel>(emailRet);
            return emailVM;
        }

        public void Remove(Guid id)
        {
            _emailService.Remove(id);
        }

        public int SaveChanges()
        {
            return _emailService.SaveChanges();
        }

        public void Dispose()
        {
            _emailService.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
