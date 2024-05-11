using Entities.Models;
using Shared.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IMachineRepository
    {
        Task<IEnumerable<Machine>> GetAllMachinesAsync(MachineParameters machineParameters, bool trackChanges);
        Task<IEnumerable<Machine>> GetAllMachinesForCompanyAsync(Guid companyId, MachineParameters machineParameters, bool trackChanges);
        Task<Machine> GetMachineAsync(Guid companyId, Guid id, bool trackChanges);
        void CreateMachine(Guid companyId, Machine machine);
        void DeleteMachine(Machine machine);
    }
}
