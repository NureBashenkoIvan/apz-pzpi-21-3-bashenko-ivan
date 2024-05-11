using Entities.Models;
using Shared.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IMachineTypeRepository
    {
        Task<IEnumerable<MachineType>> GetAllMachineTypesAsync(MachineTypeParameters machineTypeParameters, bool trackChanges);
        Task<MachineType> GetMachineTypeAsync(Guid machineTypeId, bool trackChanges);
        void CreateMachineType(MachineType machineType);
        void DeleteMachineType(MachineType machineType);
    }
}
