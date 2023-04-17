using MKTListNet.Domain.Entities;
using MKTListNet.Domain.Interface.Repository;
using MKTListNet.Domain.Interface.Services;
using System.Linq.Expressions;
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

        public Email? Add(Email email)
        {
            if (string.IsNullOrEmpty(email.EmailAddress) || !IsEmailValid(email.EmailAddress) || EmailExistente(email.EmailAddress))
                return null;

            email.EmailAddress = email.EmailAddress.Trim().ToLower();
            return _emailRepository.Add(email);
        }

        public int AddBulk(IList<string> emailbulk)
        {
            var lstEmail = new List<Email>();

            if (emailbulk == null || emailbulk.Count == 0)
                return 0;

            foreach (var item in emailbulk)
            {
                var email = item.Trim().ToLower();
                if (!IsEmailValid(email) || EmailExistente(email))
                    continue;

                lstEmail.Add(new Email { EmailAddress = email });
            }

            var tot = _emailRepository.AddBulk(lstEmail);
            return tot;
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



        public IEnumerable<Email?> Find(Expression<Func<Email, bool>> predicate)
        {
            return _emailRepository.Find(predicate);
        }

        public async Task<IEnumerable<Email>> GetAllAsync()
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

        public Email Updeate(Email email)
        {
            return _emailRepository.Updeate(email);
        }

        public void Remove(Guid id)
        {
            _emailRepository.Remove(id);
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
