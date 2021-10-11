using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DTOModels;

namespace Operations.IOperations
{
    public interface IPCMRequestOperations
    {
        List<PCMRequestDetailsDTO> GetAllPCMRequestInfo(string userId);

        Task<List<PCMRequestDetailsDTO>> GetPCMRequestByProjectName(string ProjectName);
    }
}
