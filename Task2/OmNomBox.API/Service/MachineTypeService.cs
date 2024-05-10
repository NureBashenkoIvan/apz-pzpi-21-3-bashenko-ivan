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
    internal sealed class MachineTypeService : IMachineTypeService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public MachineTypeService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<IEnumerable<MachineTypeDto>> GetAllMachineTypesAsync(MachineTypeParameters machineTypeParameters, bool trackChanges)
        {
            var machineTypes = await _repository.MachineType.GetAllMachineTypesAsync(machineTypeParameters, trackChanges);

            var machineTypesDto = _mapper.Map<IEnumerable<MachineTypeDto>>(machineTypes);

            return machineTypesDto;
        }

        public async Task<MachineTypeDto> GetMachineTypeAsync(Guid id, bool trackChanges)
        {
            var machineType = await GetMachineTypeAndCheckIfItExists(id, trackChanges);

            var machineTypeDto = _mapper.Map<MachineTypeDto>(machineType);

            return machineTypeDto;
        }

        public async Task<MachineTypeDto> CreateMachineTypeAsync(CreateUpdateMachineTypeDto machineType)
        {
            var machineTypeEntity = _mapper.Map<MachineType>(machineType);

            _repository.MachineType.CreateMachineType(machineTypeEntity);
            await _repository.SaveAsync();

            var machineTypeToReturn = _mapper.Map<MachineTypeDto>(machineTypeEntity);
            return machineTypeToReturn;
        }

        public async Task DeleteMachineTypeAsync(Guid id, bool trackChanges)
        {
            var machineType = await GetMachineTypeAndCheckIfItExists(id, trackChanges);

            _repository.MachineType.DeleteMachineType(machineType);
            await _repository.SaveAsync();
        }

        public async Task UpdateMachineTypeAsync(Guid machineTypeId, CreateUpdateMachineTypeDto machineTypeForUpdate, bool trackChanges)
        {
            var machineType = await GetMachineTypeAndCheckIfItExists(machineTypeId, trackChanges);

            _mapper.Map(machineTypeForUpdate, machineType);
            await _repository.SaveAsync();
        }

        private async Task<MachineType> GetMachineTypeAndCheckIfItExists(Guid id, bool trackChanges)
        {
            var machineType = await _repository.MachineType.GetMachineTypeAsync(id, trackChanges);
            if (machineType is null)
                throw new MachineTypeNotFoundException(id);

            return machineType;
        }
    }
}
