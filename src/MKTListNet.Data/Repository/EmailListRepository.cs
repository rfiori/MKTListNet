using MKTListNet.Domain.Entities;
using MKTListNet.Domain.Interface.Repository;

namespace MKTListNet.Infra.Repository
{
    public class EmailListRepository : Repository<EmailList>, IEmailListRepository
    {
        public EmailListRepository(MKTListNetContext dBContext, IPagingRepository<EmailList> pagingRepository) : base(dBContext, pagingRepository)
        {
        }

        public async Task<IEnumerable<Email>?> GetEmailsAsync(EmailList emailLst, string? filter)
        {
            Task<IQueryable<Email>> ret;

            if (string.IsNullOrEmpty(filter))
            {
                ret = Task.FromResult(
                            from eel in _DBContext.Set<EmailEmailList>()
                            join e in _DBContext.Set<Email>() on eel.EmailId equals e.Id
                            join el in _DBContext.Set<EmailList>() on eel.EmailListId equals el.Id
                            where el.Id == emailLst.Id
                            select e
                            );
            }
            else
            {
                ret = Task.FromResult(
                            from eel in _DBContext.Set<EmailEmailList>()
                            join e in _DBContext.Set<Email>() on eel.EmailId equals e.Id
                            join el in _DBContext.Set<EmailList>() on eel.EmailListId equals el.Id
                            where el.Id == emailLst.Id && e.EmailAddress.Contains(filter)
                            select e
                            );
            }
            return await ret;
        }
    }
}
