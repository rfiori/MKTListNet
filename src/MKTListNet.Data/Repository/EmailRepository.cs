using MKTListNet.Domain.Entities;
using MKTListNet.Domain.Interface.Repository;

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

        public IPagingResult<Email>? PagingData(IEnumerable<Email>? itemsPaging, int pageSize = 30, int page = 1)
        {
            return _PagingRepository.PagingData(itemsPaging, pageSize, page);
        }
    }
}
