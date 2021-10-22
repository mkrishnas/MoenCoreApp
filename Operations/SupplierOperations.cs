using System;
using Operations.IOperations;
using System.Collections.Generic;
using DTOModels;
using Repository;
using Repository.IRepository;
using AutoMapper;
using System.Threading.Tasks;
using Models.Models;
using Microsoft.AspNetCore.Identity;
using Common;

namespace Operations
{
    public class SupplierOperations : ISupplierOperations
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        List<SupplierDTO> supplierDTO = new List<SupplierDTO>();
        private readonly UserManager<User> _userManager;
        public SupplierOperations(IMapper mapper, IUnitOfWork unitOfWork, UserManager<User> userManager)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _userManager = userManager;
        }

        public List<SupplierDTO> GetAllSuppliers()
        {
            var result = _unitOfWork.Supplier.GetAllSuppliers();
            var orgDTO = _mapper.Map<List<SupplierDTO>>(result);
            return orgDTO;
        }

        public async Task<SupplierDTO> GetSupplier(int supplierId)
        {            
            var result = await _unitOfWork.Supplier.GetAsync(supplierId);
            var orgDTO = _mapper.Map<SupplierDTO>(result);
            return orgDTO;
        }

        public List<SupplierInfoDTO> GetAllSuppliersInfo()
        {
            List<SupplierInfoDTO> lst = new List<SupplierInfoDTO>();
            
            var result = _unitOfWork.Supplier.GetAllSuppliersInfo();

            
            List<SupplierInfoDTO> lstObjSupplierInfoDTO = new List<SupplierInfoDTO>();

            foreach (var item in result)
            {
                string strProductName = string.Empty;
                List<string> strProductNames = new List<string>();
                SupplierInfoDTO objSupplierInfoDTO = new SupplierInfoDTO();

                objSupplierInfoDTO.SupplierName = item.Name;
                
                foreach (var productItem in item.SupplierProduct)
                {
                    strProductName = productItem.Product.Name;
                    strProductNames.Add(strProductName);
                }
                objSupplierInfoDTO.ProductName = strProductNames;
                lstObjSupplierInfoDTO.Add(objSupplierInfoDTO);                
            }

            lst = lstObjSupplierInfoDTO;
            var orgDTO = lst; //_mapper.Map<List<SupplierDTO>>(result);
            return orgDTO;
        }

        public async Task AddSupplier(string name)
        {
            Supplier supplier = new Supplier();
            supplier.Name = name;
            //supplier.Id = 9;
            await _unitOfWork.Supplier.AddAsync(supplier);
        }

        public async Task UpdateSupplier(string name)
        {
            Supplier supplier = await _unitOfWork.Supplier.GetAsync(7);
            supplier.Name = name;
            await _unitOfWork.Supplier.Update(supplier);
        }

        public async Task RemoveSupplier(int Id)
        {
            Supplier supplier = await _unitOfWork.Supplier.GetAsync(Id);
            await _unitOfWork.Supplier.RemoveAsync(supplier);
        }

        public async Task SendCostEmailToSupplier(int supplierId)
        {
            EmailQueue entity = new EmailQueue();
            try
            {
                var result = await _unitOfWork.Supplier.GetAsync(supplierId);
                var emailTemplate = await _unitOfWork.EmailQueue.GetEmailTemplateByType(EmailType.CostNotificationToSupplier);
                var emailHeaderFooter = await _unitOfWork.EmailQueue.GetEmailHeaderFooter();
                var emailSetting = await _unitOfWork.EmailQueue.GetEmailSMTPInfo();
                string toEmail = string.Empty;
                string subjectEmail = string.Empty;
                var user = await _userManager.FindByNameAsync("amitverma"); // to be replaced with dynamic value 
                if (user != null)
                    toEmail = user.Email;
                string emailBody = string.Empty;
                if (emailTemplate != null)
                {
                    emailBody = emailTemplate.Template;
                    emailBody = emailBody.Replace("#Supplier", result.Name);
                    emailBody = emailBody.Replace("#User", user != null ? user.UserName : string.Empty);
                    subjectEmail = emailTemplate.EmailSubject;
                }

                if (emailHeaderFooter != null)
                    emailBody = emailHeaderFooter.TemplateHeader + emailBody + emailHeaderFooter.TemplateFooter;

                entity.EmailFrom = emailSetting != null ? emailSetting.SMPTUserName : toEmail;
                entity.EmailTo = toEmail;
                entity.EmailBody = emailBody;
                entity.EmailSubject = subjectEmail;
                await _unitOfWork.EmailQueue.AddAsync(entity);

                EmailUtility.SendEmail(emailSetting, entity);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (entity != null)
                {
                    entity.IsSent = true;
                    await _unitOfWork.EmailQueue.Update(entity);
                }

            }
        }
    }
}
