using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Shared.RequestFeatures;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class MachineStatusRepository : RepositoryBase<MachineStatus>, IMachineStatusRepository
    {
        public MachineStatusRepository(RepositoryContext repositoryContext)
        : base(repositoryContext)
        {
        }

        public async Task<IEnumerable<MachineStatus>> GetAllMachineStatusesAsync(MachineStatusParameters machineStatusParameters, bool trackChanges) =>
            await FindAll(trackChanges)
                .Skip((machineStatusParameters.PageNumber - 1) * machineStatusParameters.PageSize)
                .Take(machineStatusParameters.PageSize)
                .ToListAsync();

        public async Task<MachineStatus> GetMachineStatusAsync(Guid machineStatusId, bool trackChanges) =>
            await FindByCondition(c => c.MachineStatusId.Equals(machineStatusId), trackChanges)
            .SingleOrDefaultAsync();

        public void CreateMachineStatus(MachineStatus machineStatus) => Create(machineStatus);

        public void DeleteMachineStatus(MachineStatus machineStatus) => Delete(machineStatus);
    }
}
