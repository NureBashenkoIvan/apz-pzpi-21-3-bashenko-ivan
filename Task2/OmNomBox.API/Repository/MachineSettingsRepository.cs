using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Shared.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class MachineSettingsRepository : RepositoryBase<MachineSettings>, IMachineSettingsRepository
    {
        public MachineSettingsRepository(RepositoryContext repositoryContext)
        : base(repositoryContext)
        {
        }

        public async Task<IEnumerable<MachineSettings>> GetAllMachineSettingsAsync(MachineSettingsParameters machineSettingsParameters, 
            bool trackChanges) =>
            await FindAll(trackChanges)
            .Skip((machineSettingsParameters.PageNumber - 1) * machineSettingsParameters.PageSize)
            .Take(machineSettingsParameters.PageSize)
            .ToListAsync();

        public async Task<IEnumerable<MachineSettings>> GetAllMachineSettingsForMachineTypeAsync(Guid machineTypeId, 
            MachineSettingsParameters machineSettingsParameters, bool trackChanges) =>
            await FindByCondition(m => m.MachineTypeId.Equals(machineTypeId), trackChanges)
            .Skip((machineSettingsParameters.PageNumber - 1) * machineSettingsParameters.PageSize)
            .Take(machineSettingsParameters.PageSize)
            .ToListAsync();

        public async Task<MachineSettings> GetMachineSettingsAsync(Guid id, bool trackChanges) =>
            await FindByCondition(c => c.MachineSettingsId.Equals(id), trackChanges)
            .SingleOrDefaultAsync();

        public void CreateMachineSettingsForMachineType(Guid machineTypeId, MachineSettings machineSettings)
        {
            machineSettings.MachineTypeId = machineTypeId;
            Create(machineSettings);
        }

        public void DeleteMachineSettings(MachineSettings machineSettings) => Delete(machineSettings);
    }
}
