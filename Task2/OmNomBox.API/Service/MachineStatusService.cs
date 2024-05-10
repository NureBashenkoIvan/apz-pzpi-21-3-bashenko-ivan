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
    internal sealed class MachineStatusService : IMachineStatusService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public MachineStatusService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<IEnumerable<MachineStatusDto>> GetAllMachineStatusesAsync(MachineStatusParameters machineStatusParameters, bool trackChanges)
        {
            var machineStatuses = await _repository.MachineStatus.GetAllMachineStatusesAsync(machineStatusParameters, trackChanges);

            var machineStatusesDto = _mapper.Map<IEnumerable<MachineStatusDto>>(machineStatuses);

            return machineStatusesDto;
        }

        public async Task<MachineStatusDto> GetMachineStatusAsync(Guid id, bool trackChanges)
        {
            var machineStatus = await GetMachineStatusAndCheckIfItExists(id, trackChanges);

            var machineStatusDto = _mapper.Map<MachineStatusDto>(machineStatus);

            return machineStatusDto;
        }

        public async Task<MachineStatusDto> CreateMachineStatusAsync(CreateUpdateMachineStatusDto machineStatus)
        {
            var machineStatusEntity = _mapper.Map<MachineStatus>(machineStatus);

            _repository.MachineStatus.CreateMachineStatus(machineStatusEntity);
            await _repository.SaveAsync();

            var machineStatusToReturn = _mapper.Map<MachineStatusDto>(machineStatusEntity);
            return machineStatusToReturn;
        }

        public async Task DeleteMachineStatusAsync(Guid id, bool trackChanges)
        {
            var machineStatus = await GetMachineStatusAndCheckIfItExists(id, trackChanges);

            _repository.MachineStatus.DeleteMachineStatus(machineStatus);
            await _repository.SaveAsync();
        }

        public async Task UpdateMachineStatusAsync(Guid machineStatusId, CreateUpdateMachineStatusDto machineStatusForUpdate, bool trackChanges)
        {
            var machineStatus = await GetMachineStatusAndCheckIfItExists(machineStatusId, trackChanges);

            _mapper.Map(machineStatusForUpdate, machineStatus);
            await _repository.SaveAsync();
        }

        private async Task<MachineStatus> GetMachineStatusAndCheckIfItExists(Guid id, bool trackChanges)
        {
            var machineStatus = await _repository.MachineStatus.GetMachineStatusAsync(id, trackChanges);
            if (machineStatus is null)
                throw new MachineStatusNotFoundException(id);

            return machineStatus;
        }
    }
}
