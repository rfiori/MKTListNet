using MKTListNet.Domain.Entities;
using MKTListNet.Domain.Interfaces.Repository;
using MKTListNet.Domain.Interfaces.Services;
using System.Linq.Expressions;

namespace MKTListNet.Domain.Services
{
    public class EmailListService : IEmailListService
    {
        private readonly IEmailListRepository _emailListRepository;

        //----------------------------------------------------------//

        public EmailListService(IEmailListRepository emailListRepository)
        {
            _emailListRepository = emailListRepository;
        }

        //----------------------------------------------------------//

        public int Add(EmailList list)
        {
            if (list == null || string.IsNullOrEmpty(list.Name) || ListExistente(list.Name.Trim().ToLower()))
                return 0;

            list.Name = list.Name.Trim();
            return _emailListRepository.Add(list);
        }

        private bool ListExistente(string name)
        {
            return string.IsNullOrEmpty(name) || GetByListName(name)?.Count() > 0;
        }

        //public IPagingResult<EmailList>? GetEmails(string containsEmailList, int pageSize = 100, int page = 1)
        //{
        //    pageSize = pageSize == 0 ? 100 : pageSize;
        //    page = page == 0 ? 1 : pageSize;
        //    return _emailListRepository.FindPaging(em => em.Name.Contains(containsEmail), pageSize, page);
        //}

        public IEnumerable<EmailList>? Find(Expression<Func<EmailList, bool>> predicate)
        {
            return _emailListRepository.Find(predicate);
        }

        //public async Task<IPagingResult<EmailList>?> GetAllPagingAsync(int pageSize = 50, int page = 1)
        //{
        //    pageSize = pageSize == 0 ? 50 : pageSize;
        //    page = page == 0 ? 1 : page;
        //    return await _emailListRepository.GetAllPagingAsync(pageSize, page);
        //}

        public async Task<IEnumerable<EmailList>?> GetAllAsync()
        {
            return await _emailListRepository.GetAllAsync();
        }

        public IEnumerable<EmailList>? GetByListName(string listName)
        {
            return string.IsNullOrEmpty(listName) ? null : Find(e => e.Name.ToUpper()!.Contains(listName.ToUpper()));
        }

        public async Task<EmailList?> GetByIdAsync(int id)
        {
            return await _emailListRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Email>?> GetEmailsAsync(EmailList emailLst, string? filter)
        {
            return await _emailListRepository.GetEmailsAsync(emailLst, filter);
        }

        public EmailList? Update(EmailList email)
        {
            return _emailListRepository.Update(email);
        }

        public int Remove(int id)
        {
            return _emailListRepository.Remove(id);
        }

        public int SaveChanges()
        {
            return _emailListRepository.SaveChanges();
        }

        public void Dispose()
        {
            _emailListRepository.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
