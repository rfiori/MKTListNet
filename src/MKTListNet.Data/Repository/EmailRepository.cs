using MKTListNet.CrossCutting.Shared.Interfaces;
using MKTListNet.Domain.Entities;
using MKTListNet.Domain.Interfaces.Repository;
using System.Linq.Expressions;

namespace MKTListNet.Infra.Repository
{
    public class EmailRepository : Repository<Email>, IEmailRepository
    {
        public EmailRepository(MKTListNetContext dBContext, IPagingRepository<Email> pagingRepository) : base(dBContext, pagingRepository)
        {
        }


        public Email? GetByEmail(string email)
        {
            return Find(e => e.EmailAddress == email)?.FirstOrDefault();
        }

        public async Task<ICollection<EmailList>?> GetEmailListAsync(Email email)
        {
            //string q = "SELECT el.Id, el.Name, el.Type" +
            //           " FROM EmailEmailList eel" +
            //           " INNER JOIN EmailList el ON eel.EmailListId = el.Id" +
            //           " INNER JOIN Email e ON eel.EmailId = e.Id" +
            //          $" WHERE e.Id = {email.Id}";

            var q = await Task.FromResult(
                    from eel in _DBContext.Set<EmailEmailList>()
                    join el in _DBContext.Set<EmailList>() on eel.EmailListId equals el.Id
                    join e in _DBContext.Set<Email>() on eel.EmailId equals e.Id
                    where e.Id == email.Id
                    select el
                );

            return q.ToList();
        }

        public IPagingResult<Email>? PagingData(IEnumerable<Email>? itemsPaging, int pageSize = 30, int page = 1)
        {
            return _PagingRepository.PagingData(itemsPaging, pageSize, page);
        }

        public IPagingResult<Email>? PagingData(dynamic dbSet, int pageSize = 30, int page = 1, Expression<Func<Email, bool>>? predicate = null)
        {
            return _PagingRepository.PagingData(dbSet, pageSize, page, predicate);
        }
    }
}
