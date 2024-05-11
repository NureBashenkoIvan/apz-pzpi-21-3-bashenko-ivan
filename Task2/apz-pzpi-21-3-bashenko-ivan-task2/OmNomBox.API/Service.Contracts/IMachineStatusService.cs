using Shared.DataTransferObjects;
using Shared.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface IMachineStatusService
    {
        Task<IEnumerable<MachineStatusDto>> GetAllMachineStatusesAsync(MachineStatusParameters machineStatusParameters, bool trackChanges);
        Task<MachineStatusDto> GetMachineStatusAsync(Guid id, bool trackChanges);
        Task<MachineStatusDto> CreateMachineStatusAsync(CreateUpdateMachineStatusDto machineStatus);
        Task DeleteMachineStatusAsync(Guid id, bool trackChanges);
        Task UpdateMachineStatusAsync(Guid machineStatusId, CreateUpdateMachineStatusDto machineStatusForUpdate, bool trackChanges);
    }
}
