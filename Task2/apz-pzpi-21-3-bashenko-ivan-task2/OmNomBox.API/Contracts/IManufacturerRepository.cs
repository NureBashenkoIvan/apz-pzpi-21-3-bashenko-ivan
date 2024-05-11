using Entities.Models;
using Shared.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IManufacturerRepository
    {
        Task<IEnumerable<Manufacturer>> GetAllManufacturersAsync(ManufacturerParameters manufacturerParameters,
        bool trackChanges);
        Task<Manufacturer> GetManufacturerAsync(Guid manufacturerId, bool trackChanges);
        void CreateManufacturer(Manufacturer manufacturer);
        void DeleteManufacturer(Manufacturer manufacturer);
    }
}
