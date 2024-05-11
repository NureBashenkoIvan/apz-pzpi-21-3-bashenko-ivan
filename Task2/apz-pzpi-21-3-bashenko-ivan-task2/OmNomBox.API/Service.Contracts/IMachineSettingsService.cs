using Shared.DataTransferObjects;
using Shared.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface IMachineSettingsService
    {
        Task<IEnumerable<MachineSettingsDto>> GetAllMachineSettingsAsync(MachineSettingsParameters machineSettingsParameters, bool trackChanges);
        Task<IEnumerable<MachineSettingsDto>> GetAllMachineSettingsForMachineTypeAsync(Guid machineTypeId, MachineSettingsParameters machineSettingsParameters, bool trackChanges);
        Task<MachineSettingsDto> GetMachineSettingsAsync(Guid id, bool trackChanges);
        Task<MachineSettingsDto> CreateMachineSettingsAsync(Guid machineTypeId, CreateUpdateMachineSettingsDto machineSettings);
        Task DeleteMachineSettingsAsync(Guid id, bool trackChanges);
        Task UpdateMachineSettingsAsync(Guid machineTypeId, Guid id, CreateUpdateMachineSettingsDto machineSettingsForUpdate, bool trackChanges);
    }
}
