using MKTListNet.Domain.Entities;

namespace MKTListNet.Domain.Interface
{
    public interface IEmailRepository : IRepository<Email>
    {
        Email? GetByEmail(string email);
    }
}
