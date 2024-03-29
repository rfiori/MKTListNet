﻿using MKTListNet.Domain.Entities;

namespace MKTListNet.Domain.Interfaces.Repository
{
    public interface IEmailListRepository : IRepository<EmailList>
    {
        Task<IEnumerable<Email>?> GetEmailsAsync(EmailList emailLst, string? filter);
    }

}
