using Microsoft.EntityFrameworkCore;
using Models.Models;
using Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class EmailQueueRepository : RepositoryAsync<EmailQueue>, IEmailQueueRepository
    {

        private readonly MOENPCMContext _context;
        public EmailQueueRepository(MOENPCMContext context) : base(context)
        {
            this._context = context;
        }

        public async Task<EmailTemplate> GetEmailTemplateByType(string emailtype)
        {
            try
            {
                var cq = this._context.EmailTemplates
                .Where(p => p.EmailType == emailtype)
                .AsNoTracking();
                return await cq.FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<EmailHeaderFooter> GetEmailHeaderFooter()
        {
            try
            {
                var cq = this._context.EmailHeaderFooter
                .AsNoTracking();
                return await cq.FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public async Task<EmailSMTPInfo> GetEmailSMTPInfo()
        {
            try
            {
                var cq = this._context.EmailSMTPInfo
                .AsNoTracking();
                return await cq.FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
