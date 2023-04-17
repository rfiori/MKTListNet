using MKTListNet.Domain.Entities;

namespace MKTListNet.Domain.Interface.Repository
{
    public interface IEmailRepository : IRepository<Email>
    {
        Email? GetByEmail(string email);
    }
}
