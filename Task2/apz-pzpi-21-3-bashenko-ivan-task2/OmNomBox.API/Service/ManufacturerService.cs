using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
using Service.Contracts;
using Shared.DataTransferObjects;
using Shared.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    internal sealed class ManufacturerService : IManufacturerService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public ManufacturerService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }
        public async Task<IEnumerable<ManufacturerDto>> GetAllManufacturersAsync(ManufacturerParameters manufacturerParameters, bool trackChanges)
        {
            var manufacturers = await _repository.Manufacturer.GetAllManufacturersAsync(manufacturerParameters, trackChanges);

            var manufacturersDto = _mapper.Map<IEnumerable<ManufacturerDto>>(manufacturers);

            return manufacturersDto;
        }

        public async Task<ManufacturerDto> GetManufacturerAsync(Guid id, bool trackChanges)
        {
            var manufacturer = await GetManufacturerAndCheckIfItExists(id, trackChanges);

            var manufacturerDto = _mapper.Map<ManufacturerDto>(manufacturer);

            return manufacturerDto;
        }

        public async Task<ManufacturerDto> CreateManufacturerAsync(CreateUpdateManufacturerDto manufacturer)
        {
            var manufacturerEntity = _mapper.Map<Manufacturer>(manufacturer);

            _repository.Manufacturer.CreateManufacturer(manufacturerEntity);
            await _repository.SaveAsync();

            var manufacturerToReturn = _mapper.Map<ManufacturerDto>(manufacturerEntity);
            return manufacturerToReturn;
        }

        public async Task DeleteManufacturerAsync(Guid id, bool trackChanges)
        {
            var manufacturer = await GetManufacturerAndCheckIfItExists(id, trackChanges);

            _repository.Manufacturer.DeleteManufacturer(manufacturer);
            await _repository.SaveAsync();
        }

        public async Task UpdateManufacturerAsync(Guid manufacturerId, CreateUpdateManufacturerDto manufacturerForUpdate, bool trackChanges)
        {
            var manufacturer = await GetManufacturerAndCheckIfItExists(manufacturerId, trackChanges);

            _mapper.Map(manufacturerForUpdate, manufacturer);
            await _repository.SaveAsync();
        }

        private async Task<Manufacturer> GetManufacturerAndCheckIfItExists(Guid id, bool trackChanges)
        {
            var manufacturer = await _repository.Manufacturer.GetManufacturerAsync(id, trackChanges);
            if (manufacturer is null)
                throw new ManufacturerNotFoundException(id);

            return manufacturer;
        }
    }
}
