using MKTListNet.Domain.Entities;

namespace MKTListNet.Domain.Interface
{
    public interface IEmailListRepository : IRepository<EmailList>
    {
        EmailList? GetByName(string name);
    }
}
