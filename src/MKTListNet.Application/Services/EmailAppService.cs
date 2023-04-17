using AutoMapper;
using MKTListNet.Application.Interface;
using MKTListNet.Application.ViewModel;
using MKTListNet.Domain.Entities;
using MKTListNet.Domain.Interface.Services;
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

        public EmailViewModel Add(EmailViewModel emailVM)
        {
            var email = _mapper.Map<Email>(emailVM);
            var emailRet = _emailService.Add(email);
            if (emailRet != null)
            {
                _emailService.SaveChanges();
            }
            emailVM = _mapper.Map<EmailViewModel>(emailRet);
            return emailVM;
        }

        public int AddBulk(IList<string> emailbulk)
        {
            return _emailService.AddBulk(emailbulk);
        }

        public IEnumerable<EmailViewModel?> Find(Expression<Func<EmailViewModel, bool>> predicate)
        {
            var pred = _mapper.Map<Expression<Func<Email, bool>>>(predicate);
            return _mapper.Map<IEnumerable<EmailViewModel>>(_emailService.Find(pred));
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
            var emailRet = _emailService.Updeate(email);
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
