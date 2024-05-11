using Shared.DataTransferObjects;
using Shared.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface IMachineTypeService
    {
        Task<IEnumerable<MachineTypeDto>> GetAllMachineTypesAsync(MachineTypeParameters machineTypeParameters, bool trackChanges);
        Task<MachineTypeDto> GetMachineTypeAsync(Guid id, bool trackChanges);
        Task<MachineTypeDto> CreateMachineTypeAsync(CreateUpdateMachineTypeDto machineType);
        Task DeleteMachineTypeAsync(Guid id, bool trackChanges);
        Task UpdateMachineTypeAsync(Guid machineTypeId, CreateUpdateMachineTypeDto machineTypeForUpdate, bool trackChanges);
    }
}
