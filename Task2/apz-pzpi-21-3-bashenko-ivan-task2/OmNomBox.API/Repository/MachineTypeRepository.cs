using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Shared.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class MachineTypeRepository : RepositoryBase<MachineType>, IMachineTypeRepository
    {
        public MachineTypeRepository(RepositoryContext repositoryContext)
        : base(repositoryContext)
        {
        }

        public async Task<IEnumerable<MachineType>> GetAllMachineTypesAsync(MachineTypeParameters machineTypeParameters, bool trackChanges) =>
            await FindAll(trackChanges)
                .OrderBy(c => c.Name)
                .Skip((machineTypeParameters.PageNumber - 1) * machineTypeParameters.PageSize)
                .Take(machineTypeParameters.PageSize)
                .ToListAsync();

        public async Task<MachineType> GetMachineTypeAsync(Guid machineTypeId, bool trackChanges) =>
            await FindByCondition(c => c.MachineTypeId.Equals(machineTypeId), trackChanges)
            .SingleOrDefaultAsync();

        public void CreateMachineType(MachineType machineType) => Create(machineType);

        public void DeleteMachineType(MachineType machineType) => Delete(machineType);
    }
}
