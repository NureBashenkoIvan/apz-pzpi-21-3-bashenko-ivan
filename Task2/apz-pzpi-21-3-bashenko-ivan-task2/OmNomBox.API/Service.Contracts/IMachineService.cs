using Shared.DataTransferObjects;
using Shared.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface IMachineService
    {
        Task<IEnumerable<MachineDto>> GetAllMachinesAsync(MachineParameters machineParameters, bool trackChanges);
        Task<IEnumerable<MachineDto>> GetAllMachinesForCompanyAsync(Guid companyId, MachineParameters machineParameters, bool trackChanges);
        Task<MachineDto> GetMachineAsync(Guid companyId, Guid id, bool trackChanges);
        Task<MachineDto> CreateMachineAsync(Guid companyId, CreateUpdateMachineDto machineForCreation,
            bool trackChanges);
        Task DeleteMachineAsync(Guid companyId, Guid id, bool trackChanges);
        Task UpdateMachineAsync(Guid companyId, Guid id, CreateUpdateMachineDto machineForUpdate, bool trackChanges);
    }
}
