using MKTListNet.CrossCutting.Shared.Interfaces;
using MKTListNet.Domain.Entities;
using MKTListNet.Domain.Interfaces.Repository;

namespace MKTListNet.Infra.Repository
{
    public class EmailEmailListRepository : Repository<EmailEmailList>, IEmailEmailListRepository
    {
        public EmailEmailListRepository(MKTListNetContext dBContext, IPagingRepository<EmailEmailList> pagingRepository) : base(dBContext, pagingRepository)
        {
        }
    }
}
