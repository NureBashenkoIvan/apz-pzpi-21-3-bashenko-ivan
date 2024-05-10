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
    public class ManufacturerRepository : RepositoryBase<Manufacturer>, IManufacturerRepository
    {
        public ManufacturerRepository(RepositoryContext repositoryContext)
        : base(repositoryContext)
        {
        }

        public async Task<IEnumerable<Manufacturer>> GetAllManufacturersAsync(ManufacturerParameters manufacturerParameters, bool trackChanges) =>
            await FindAll(trackChanges)
                .OrderBy(c => c.Name)
                .Skip((manufacturerParameters.PageNumber - 1) * manufacturerParameters.PageSize)
                .Take(manufacturerParameters.PageSize)
                .ToListAsync();

        public async Task<Manufacturer> GetManufacturerAsync(Guid manufacturerId, bool trackChanges) =>
            await FindByCondition(c => c.ManufacturerId.Equals(manufacturerId), trackChanges)
            .SingleOrDefaultAsync();

        public void CreateManufacturer(Manufacturer manufacturer) => Create(manufacturer);

        public void DeleteManufacturer(Manufacturer manufacturer) => Delete(manufacturer);
    }
}
