using MKTListNet.Domain.Entities;
using MKTListNet.Domain.Interface.Repository;

namespace MKTListNet.Infra.Repository
{
    public class EmailEmailListRepository : Repository<EmailEmailList>, IEmailEmailListRepository
    {
        public EmailEmailListRepository(MKTListNetContext dBContext) : base(dBContext)
        {
        }
    }
}
