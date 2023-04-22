using MKTListNet.Domain.Entities;

namespace MKTListNet.Domain.Interface.Repository
{
    public interface IEmailRepository : IRepository<Email>
    {
        Task<int> AddBulkAsync(IList<Email> lstEmail);

        Email? GetByEmail(string email);
    }
}
