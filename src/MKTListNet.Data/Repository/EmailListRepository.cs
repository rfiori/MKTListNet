using MKTListNet.Domain.Entities;
using MKTListNet.Domain.Interface.Repository;

namespace MKTListNet.Infra.Repository
{
    public class EmailListRepository : Repository<EmailList>, IEmailListRepository
    {
        public EmailListRepository(MKTListNetContext dBContext) : base(dBContext) { }
    }
}
