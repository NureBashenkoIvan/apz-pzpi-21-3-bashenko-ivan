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
    internal sealed class MachineService : IMachineService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public MachineService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<IEnumerable<MachineDto>> GetAllMachinesAsync(MachineParameters machineParameters, bool trackChanges)
        {
            var machinesFromDb = await _repository.Machine.GetAllMachinesAsync(machineParameters, trackChanges);
            var machinesDto = _mapper.Map<IEnumerable<MachineDto>>(machinesFromDb);

            return machinesDto;
        }

        public async Task<IEnumerable<MachineDto>> GetAllMachinesForCompanyAsync(Guid companyId, MachineParameters machineParameters, bool trackChanges)
        {
            await CheckIfCompanyExists(companyId, trackChanges);

            var machinesFromDb = await _repository.Machine.GetAllMachinesForCompanyAsync(companyId, machineParameters, trackChanges);
            var machinesDto = _mapper.Map<IEnumerable<MachineDto>>(machinesFromDb);

            return machinesDto;
        }

        public async Task<MachineDto> GetMachineAsync(Guid companyId, Guid id, bool trackChanges)
        {
            await CheckIfCompanyExists(companyId, trackChanges);

            var machineDb = await _repository.Machine.GetMachineAsync(companyId, id, trackChanges);
            if (machineDb is null)
                throw new MachineNotFoundException(id);

            var machine = _mapper.Map<MachineDto>(machineDb);
            return machine;
        }

        public async Task<MachineDto> CreateMachineAsync(Guid companyId, CreateUpdateMachineDto machineForCreation, bool trackChanges)
        {
            await CheckIfCompanyExists(companyId, trackChanges);

            var machineEntity = _mapper.Map<Machine>(machineForCreation);

            _repository.Machine.CreateMachine(companyId, machineEntity);
            await _repository.SaveAsync();

            var machineToReturn = _mapper.Map<MachineDto>(machineEntity);
            return machineToReturn;
        }

        public async Task UpdateMachineAsync(Guid companyId, Guid id, CreateUpdateMachineDto machineForUpdate, bool trackChanges)
        {
            await CheckIfCompanyExists(companyId, trackChanges);

            var machineDb = await GetMachineForCompanyAndCheckIfItExists(companyId, id, trackChanges);

            _mapper.Map(machineForUpdate, machineDb);
            await _repository.SaveAsync();
        }

        public async Task DeleteMachineAsync(Guid companyId, Guid id, bool trackChanges)
        {
            await CheckIfCompanyExists(companyId, trackChanges);

            var machineDb = await GetMachineForCompanyAndCheckIfItExists(companyId, id, trackChanges);

            _repository.Machine.DeleteMachine(machineDb);
            await _repository.SaveAsync();
        }

        private async Task CheckIfCompanyExists(Guid companyId, bool trackChanges)
        {
            var company = await _repository.Company.GetCompanyAsync(companyId, trackChanges);

            if (company is null)
                throw new CompanyNotFoundException(companyId);
        }

        private async Task<Machine> GetMachineForCompanyAndCheckIfItExists(Guid companyId, Guid id, bool trackChanges)
        {
            var companyDb = await _repository.Machine.GetMachineAsync(companyId, id, trackChanges);
            if (companyDb is null)
                throw new CompanyNotFoundException(id);

            return companyDb;
        }
    }
}
