using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Extensions;
using Shared.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class MachineRepository : RepositoryBase<Machine>, IMachineRepository
    {
        public MachineRepository(RepositoryContext repositoryContext)
        : base(repositoryContext)
        {
        }

        public async Task<IEnumerable<Machine>> GetAllMachinesAsync(MachineParameters machineParameters, bool trackChanges) =>
            await FindAll(trackChanges)
                    .Sort(machineParameters.OrderBy)
                    .Search(machineParameters.SearchTerm)
                    .Skip((machineParameters.PageNumber - 1) * machineParameters.PageSize)
                    .Take(machineParameters.PageSize)
                    .ToListAsync();

        public async Task<IEnumerable<Machine>> GetAllMachinesForCompanyAsync(Guid companyId, MachineParameters machineParameters, bool trackChanges) =>
            await FindByCondition(e => e.CompanyId.Equals(companyId), trackChanges)
                     .Sort(machineParameters.OrderBy)
                     .Search(machineParameters.SearchTerm)
                     .Skip((machineParameters.PageNumber - 1) * machineParameters.PageSize)
                     .Take(machineParameters.PageSize)
                     .ToListAsync();

        public async Task<Machine> GetMachineAsync(Guid companyId, Guid id, bool trackChanges) =>
            await FindByCondition(e => e.CompanyId.Equals(companyId) && e.MachineId.Equals(id), trackChanges)
            .SingleOrDefaultAsync();

        public void CreateMachine(Guid companyId, Machine machine)
        {
            machine.CompanyId = companyId;
            Create(machine);
        }

        public void DeleteMachine(Machine machine) => Delete(machine);
    }
}
