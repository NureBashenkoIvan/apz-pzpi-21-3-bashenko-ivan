using Entities.Models;
using Shared.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IMachineSettingsRepository
    {
        Task<IEnumerable<MachineSettings>> GetAllMachineSettingsAsync(MachineSettingsParameters machineSettingsParameters, bool trackChanges);
        Task<IEnumerable<MachineSettings>> GetAllMachineSettingsForMachineTypeAsync(Guid machineTypeId, MachineSettingsParameters machineSettingsParameters, 
            bool trackChanges);
        Task<MachineSettings> GetMachineSettingsAsync(Guid id, bool trackChanges);
        void CreateMachineSettingsForMachineType(Guid machineTypeId, MachineSettings machineSettings);
        void DeleteMachineSettings(MachineSettings machineSettings);
    }
}
