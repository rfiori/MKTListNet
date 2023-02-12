using MKTListNet.Domain.Entities;
using MKTListNet.Domain.Interface;
using MKTListNet.Infra;

namespace MKTListNet.Data.Repository
{
    public class EmailRepository : Repository<Email>, IEmailRepository
    {
        public EmailRepository(MKTListNetContext dBContext) : base(dBContext)
        { }

        public Email? GetByEmail(string email)
        {
            return Find(e => e.EmailAddress == email)?.FirstOrDefault();
        }
    }
}
