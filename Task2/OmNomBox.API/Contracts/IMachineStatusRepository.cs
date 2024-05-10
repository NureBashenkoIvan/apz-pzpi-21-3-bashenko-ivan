using Entities.Models;
using Shared.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IMachineStatusRepository
    {
        Task<IEnumerable<MachineStatus>> GetAllMachineStatusesAsync(MachineStatusParameters machineStatusParameters, bool trackChanges);
        Task<MachineStatus> GetMachineStatusAsync(Guid machineStatusId, bool trackChanges);
        void CreateMachineStatus(MachineStatus machineStatus);
        void DeleteMachineStatus(MachineStatus machineStatus);
    }
}
