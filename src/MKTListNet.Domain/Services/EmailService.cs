using MKTListNet.CrossCutting.Shared.Interfaces;
using MKTListNet.Domain.Entities;
using MKTListNet.Domain.Interfaces.Repository;
using MKTListNet.Domain.Interfaces.Services;
using System.Linq.Expressions;
using System.Text.RegularExpressions;

namespace MKTListNet.Domain.Services
{
    public class EmailService : IEmailService
    {
        private readonly IEmailRepository _emailRepository;
        private readonly IEmailListRepository _emailListRepository;
        private readonly IEmailEmailListRepository _emailEmlLstRepository;

        //----------------------------------------------------------//

        public EmailService(IEmailRepository emailRep, IEmailListRepository emailListRep, IEmailEmailListRepository emailEmlLstRep)
        {
            _emailRepository = emailRep;
            _emailListRepository = emailListRep;
            _emailEmlLstRepository = emailEmlLstRep;
        }

        //----------------------------------------------------------//

        public int Add(Email email)
        {
            if (string.IsNullOrEmpty(email.EmailAddress) || !IsEmailValid(email.EmailAddress) || EmailExistente(email.EmailAddress))
                return 0;

            email.EmailAddress = email.EmailAddress.Trim().ToLower();
            return _emailRepository.Add(email);
        }

        public async Task<int> AddBulkAsync(IList<string> lstEmail, int? listEmailId)
        {
            if (lstEmail == null || lstEmail.Count == 0)
                return 0;

            int ctAdd = 0;
            var lstEmailOk = new List<Email>();
            var generalList = await _emailListRepository.GetByIdAsync(1);
            EmailList? emlList = null;
            if (listEmailId != null && listEmailId > 0)
                emlList = await _emailListRepository.GetByIdAsync(listEmailId.Value);
            // Verificacoes para a GeneralList
            foreach (var item in lstEmail)
            {
                var email = item.Trim().ToLower();
                // Verifica se o email já existe no BD / GeneralList.
                if (!IsEmailValid(email) || EmailExistente(email))
                    continue;

                // Verifica se o email está duplicado na lista enviada.
                if (lstEmailOk.FirstOrDefault(x => x.EmailAddress == item) != null)
                    continue;

                var em = new Email { EmailAddress = email };
                //if (em?.EmailList == null || em?.EmailList.FirstOrDefault(x => x.Id == 1) == null)
                //{
                em.EmailList = new List<EmailList>();
                em.EmailList.Add(generalList!); // adiciona em GeneralList
                if (emlList != null && listEmailId != null && listEmailId > 0)
                    em.EmailList.Add(emlList);

                //_emailRepository.Update(em!);
                //}

                lstEmailOk.Add(em);
            }

            if (lstEmailOk.Count > 0)
                ctAdd = await _emailRepository.AddBulkAsync(lstEmailOk);
            // Faz a inclusão de emails ja existentes e adicionados em outra lista.
            if (lstEmail.Count > 0)
            {
                emlList = await _emailListRepository.GetByIdAsync(listEmailId!.Value);
                foreach (var item in lstEmail)
                {
                    if (listEmailId != null && listEmailId > 0)
                    {
                        //var emailEmlLst = new Collection<EmailEmailList>();
                        var em = _emailRepository.GetByEmail(item);

                        em!.EmailList = await _emailRepository.GetEmailListAsync(em);

                        if (em?.EmailList is null)
                            em!.EmailList = new List<EmailList>();

                        if (em?.EmailList?.FirstOrDefault(x => x.Id == listEmailId) == null)
                        {
                            em?.EmailList?.Add(emlList!);
                            _emailRepository.Update(em!);
                        }
                    }
                }
            }
            return ctAdd;
        }

        private bool EmailExistente(string email)
        {
            return string.IsNullOrEmpty(email) || GetByEmail(email) != null;
        }

        private static bool IsEmailValid(string email)
        {
            const string pattern = @"^[^\s@]+@[^\s@]+\.[^\s@]+$";
            return Regex.IsMatch(email, pattern);
        }

        public IPagingResult<Email>? GetEmails(string containsEmail, int emailListId = 1, int pageSize = 100, int page = 1)
        {
            // Get EmailList obj.
            var emlist = _emailListRepository.GetByIdAsync(emailListId).Result;
            // Get all emails for EmailList.
            var emLst = _emailListRepository.GetEmailsAsync(emlist!, containsEmail).Result;
            // Return Emails list paging.
            return _emailRepository.PagingData(emLst, pageSize, page);
        }

        public async Task<IPagingResult<Email>?> GetAllPagingAsync(int pageSize = 50, int page = 1)
        {
            pageSize = pageSize == 0 ? 50 : pageSize;
            page = page == 0 ? 1 : page;
            return await _emailRepository.GetAllPagingAsync(pageSize, page);
        }

        [Obsolete("Use new method GetAllPagingAsync()")]
        public async Task<IEnumerable<Email>?> GetAllAsync()
        {
            return await _emailRepository.GetAllAsync();
        }

        public Email? GetByEmail(string email)
        {
            return _emailRepository.GetByEmail(email);
        }

        public async Task<IEnumerable<EmailList>?> GetEmailListAsync(Email email)
        {
            return await _emailRepository.GetEmailListAsync(email);
        }

        public IEnumerable<Email>? Find(Expression<Func<Email, bool>> predicate)
        {
            return _emailRepository.Find(predicate);
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
