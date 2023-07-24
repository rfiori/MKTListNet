using MKTListNet.Domain.Entities;
using MKTListNet.Domain.Interface.Repository;

namespace MKTListNet.Infra.Repository
{
    public class EmailRepository : Repository<Email>, IEmailRepository
    {
        private readonly MKTListNetContext _Contex;

        public EmailRepository(MKTListNetContext dBContext) : base(dBContext)
        {
            _Contex = dBContext;
        }


        public Email? GetByEmail(string email)
        {
            return Find(e => e.EmailAddress == email)?.FirstOrDefault();
        }
    }
}
