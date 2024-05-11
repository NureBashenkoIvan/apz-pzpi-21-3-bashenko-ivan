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
    internal sealed class MachineSettingsService : IMachineSettingsService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public MachineSettingsService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<IEnumerable<MachineSettingsDto>> GetAllMachineSettingsAsync(MachineSettingsParameters machineSettingsParameters, bool trackChanges)
        {
            var machineSettingses = await _repository.MachineSettings.GetAllMachineSettingsAsync(machineSettingsParameters, trackChanges);

            var machineSettingsesDto = _mapper.Map<IEnumerable<MachineSettingsDto>>(machineSettingses);

            return machineSettingsesDto;
        }

        public async Task<IEnumerable<MachineSettingsDto>> GetAllMachineSettingsForMachineTypeAsync(Guid machineTypeId, MachineSettingsParameters machineSettingsParameters, bool trackChanges)
        {
            await CheckIfMachineTypeExists(machineTypeId, trackChanges);

            var machineSettingsesFromDb = await _repository.MachineSettings.GetAllMachineSettingsForMachineTypeAsync(machineTypeId, machineSettingsParameters, trackChanges);
            var machineSettingsesDto = _mapper.Map<IEnumerable<MachineSettingsDto>>(machineSettingsesFromDb);

            return machineSettingsesDto;
        }

        public async Task<MachineSettingsDto> GetMachineSettingsAsync(Guid id, bool trackChanges)
        {
            var machineSettings = await GetMachineSettingsAndCheckIfItExists(id, trackChanges);

            var machineSettingsDto = _mapper.Map<MachineSettingsDto>(machineSettings);

            return machineSettingsDto;
        }

        public async Task<MachineSettingsDto> CreateMachineSettingsAsync(Guid machineTypeId, CreateUpdateMachineSettingsDto machineSettings)
        {
            var machineSettingsEntity = _mapper.Map<MachineSettings>(machineSettings);
            machineSettingsEntity.MachineTypeId = machineTypeId;

            _repository.MachineSettings.CreateMachineSettingsForMachineType(machineTypeId, machineSettingsEntity);
            await _repository.SaveAsync();

            var machineSettingsToReturn = _mapper.Map<MachineSettingsDto>(machineSettingsEntity);
            return machineSettingsToReturn;
        }

        public async Task DeleteMachineSettingsAsync(Guid id, bool trackChanges)
        {
            var machineSettings = await GetMachineSettingsAndCheckIfItExists(id, trackChanges);

            _repository.MachineSettings.DeleteMachineSettings(machineSettings);
            await _repository.SaveAsync();
        }

        public async Task UpdateMachineSettingsAsync(Guid machineTypeId, Guid machineSettingsId, CreateUpdateMachineSettingsDto machineSettingsForUpdate, bool trackChanges)
        {
            var machineSettings = await GetMachineSettingsAndCheckIfItExists(machineSettingsId, trackChanges);

            _mapper.Map(machineSettingsForUpdate, machineSettings);
            await _repository.SaveAsync();
        }

        private async Task<MachineSettings> GetMachineSettingsAndCheckIfItExists(Guid id, bool trackChanges)
        {
            var machineSettings = await _repository.MachineSettings.GetMachineSettingsAsync(id, trackChanges);
            if (machineSettings is null)
                throw new MachineSettingsNotFoundException(id);

            return machineSettings;
        }

        private async Task CheckIfMachineTypeExists(Guid machineTypeId, bool trackChanges)
        {
            var machineType = await _repository.MachineType.GetMachineTypeAsync(machineTypeId, trackChanges);

            if (machineType is null)
                throw new MachineTypeNotFoundException(machineTypeId);
        }
    }
}
