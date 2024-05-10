using Shared.DataTransferObjects;
using Shared.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface IManufacturerService
    {
        Task<IEnumerable<ManufacturerDto>> GetAllManufacturersAsync(ManufacturerParameters manufacturerParameters, bool trackChanges);
        Task<ManufacturerDto> GetManufacturerAsync(Guid id, bool trackChanges);
        Task<ManufacturerDto> CreateManufacturerAsync(CreateUpdateManufacturerDto manufacturer);
        Task DeleteManufacturerAsync(Guid id, bool trackChanges);
        Task UpdateManufacturerAsync(Guid manufacturerId, CreateUpdateManufacturerDto manufacturerForUpdate, bool trackChanges);
    }
}
