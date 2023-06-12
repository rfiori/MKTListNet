using MKTListNet.Domain.Entities;
using MKTListNet.Domain.Interface.Repository;
using MKTListNet.Domain.Interface.Services;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;

namespace MKTListNet.Domain.Services
{
    public class EmailService : IEmailService
    {
        private readonly IEmailRepository _emailRepository;

        //----------------------------------------------------------//

        public EmailService(IEmailRepository emailRepository)
        {
            _emailRepository = emailRepository;
        }

        //----------------------------------------------------------//

        public int Add(Email email)
        {
            if (string.IsNullOrEmpty(email.EmailAddress) || !IsEmailValid(email.EmailAddress) || EmailExistente(email.EmailAddress))
                return 0;

            email.EmailAddress = email.EmailAddress.Trim().ToLower();
            return _emailRepository.Add(email);
        }

        public async Task<int> AddBulkAsync(IList<string> lstEmail)
        {
            if (lstEmail == null || lstEmail.Count == 0)
                return 0;

            var lstEmailOk = new List<Email>();

            foreach (var item in lstEmail)
            {
                var email = item.Trim().ToLower();
                if (!IsEmailValid(email) || EmailExistente(email))
                    continue;

                lstEmailOk.Add(new Email { EmailAddress = email });
            }

            return await _emailRepository.AddBulkAsync(lstEmailOk);
        }

        private bool EmailExistente(string email)
        {
            return string.IsNullOrEmpty(email) || GetByEmail(email) != null;
        }

        private bool IsEmailValid(string email)
        {
            string pattern = @"^[^\s@]+@[^\s@]+\.[^\s@]+$";
            return Regex.IsMatch(email, pattern);
        }

        public IPagingResult<Email>? GetEmails(string containsEmail, int pageSize = 100, int page = 1)
        {
            pageSize = pageSize == 0 ? 100 : pageSize;
            page = page == 0 ? 1 : page;
            return _emailRepository.FindPaging(em => em.EmailAddress.Contains(containsEmail), pageSize, page);
        }

        public IEnumerable<Email>? Find(Expression<Func<Email, bool>> predicate)
        {
            return _emailRepository.Find(predicate);
        }

        public async Task<IPagingResult<Email>?> GetAllPagingAsync(int pageSize = 50, int page = 1)
        {
            pageSize = pageSize == 0 ? 50 : pageSize;
            page = page == 0 ? 1 : page;
            return await _emailRepository.GetAllPagingAsync(pageSize, page);
        }

        public async Task<IEnumerable<Email>?> GetAllAsync()
        {
            return await _emailRepository.GetAllAsync();
        }

        public Email? GetByEmail(string email)
        {
            return _emailRepository.GetByEmail(email);
        }

        public async Task<Email?> GetByIdAsync(Guid id)
        {
            return await _emailRepository.GetByIdAsync(id);
        }

        public Email? Update(Email email)
        {
            return _emailRepository.Update(email);
        }

        public int Remove(Guid id)
        {
            return _emailRepository.Remove(id);
        }

        public int SaveChanges()
        {
            return _emailRepository.SaveChanges();
        }

        public void Dispose()
        {
            _emailRepository.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
