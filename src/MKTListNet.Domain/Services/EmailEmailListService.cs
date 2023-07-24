using MKTListNet.Domain.Entities;
using MKTListNet.Domain.Interface.Repository;
using MKTListNet.Domain.Interface.Services;
using System.Collections.ObjectModel;

namespace MKTListNet.Domain.Services
{
    public class EmailEmailListService : IEmailEmailListService
    {
        private readonly IEmailEmailListRepository _emailEmlLstReopsitory;

        //----------------------------------------------------------//

        public EmailEmailListService(IEmailEmailListRepository emailEmlLstRepository)
        {
            _emailEmlLstReopsitory = emailEmlLstRepository;
        }

        //----------------------------------------------------------//

        public int Add(Guid emailId, int emailListId)
        {
            if (emailId == Guid.Empty || emailListId <= 0)
                return 0;
            return _emailEmlLstReopsitory.Add(new EmailEmailList { EmailId = emailId, EmailListId = emailListId });
        }

        public async Task<int> AddBulkAsync(IList<Guid> lstEmail, int emailListId)
        {
            if (lstEmail == null || lstEmail.Count <= 0 || emailListId <= 0)
                return 0;
            var lst = new Collection<EmailEmailList>();

            foreach (var item in lstEmail)
                lst.Add(new EmailEmailList { EmailId = item!, EmailListId = emailListId });

            return await _emailEmlLstReopsitory.AddBulkAsync(lst);
        }

        public IEnumerable<EmailEmailList>? GetByEmailId(Guid emailId)
        {
            return _emailEmlLstReopsitory.Find(x => x.EmailId == emailId);
        }

        public IEnumerable<EmailEmailList>? GetByEmailListId(int emailListId)
        {
            return _emailEmlLstReopsitory.Find(x => x.EmailListId == emailListId);
        }

        public int RemoveEmailId(Guid emailId)
        {
            return _emailEmlLstReopsitory.Remove(emailId);
        }

        public int RemoveEmailListId(int emailEmlLstId)
        {
            return _emailEmlLstReopsitory.Remove(emailEmlLstId);
        }

        public EmailEmailList? Update(EmailEmailList emailEmlLst)
        {
            return _emailEmlLstReopsitory.Update(emailEmlLst);
        }

        public int SaveChanges()
        {
            return _emailEmlLstReopsitory.SaveChanges();
        }

        public void Dispose()
        {
            _emailEmlLstReopsitory.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
