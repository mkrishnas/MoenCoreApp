using Models.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Repository.IRepository
{
    public interface IEmailQueueRepository : IRepositoryAsync<EmailQueue>
    {
        Task<EmailTemplate> GetEmailTemplateByType(string emailtype);
        Task<EmailHeaderFooter> GetEmailHeaderFooter();
        Task<EmailSMTPInfo> GetEmailSMTPInfo();
    }
}
