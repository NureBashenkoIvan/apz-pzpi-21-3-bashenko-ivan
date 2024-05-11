using Contracts;

namespace Repository
{
    public sealed class RepositoryManager : IRepositoryManager
    {
        private readonly RepositoryContext _repositoryContext;
        private readonly Lazy<IMachineRepository> _machineRepository;
        private readonly Lazy<IMachineStatusRepository> _machineStatusRepository;
        private readonly Lazy<IMachineTypeRepository> _machineTypeRepository;
        private readonly Lazy<IMachineSettingsRepository> _machineSettingsRepository;
        private readonly Lazy<IManufacturerRepository> _manufacturerRepository;
        private readonly Lazy<IMealRepository> _mealRepository;
        private readonly Lazy<ICompanyRepository> _companyRepository;
        private readonly Lazy<IOrderRepository> _orderRepository;
        private readonly Lazy<IBackupRepository> _backupRepository;

        public RepositoryManager(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
            _machineRepository = new Lazy<IMachineRepository>(() => new MachineRepository(repositoryContext));
            _machineStatusRepository = new Lazy<IMachineStatusRepository>(() => new MachineStatusRepository(repositoryContext));
            _machineTypeRepository = new Lazy<IMachineTypeRepository>(() => new MachineTypeRepository(repositoryContext));
            _machineSettingsRepository = new Lazy<IMachineSettingsRepository>(() => new MachineSettingsRepository(repositoryContext));
            _manufacturerRepository = new Lazy<IManufacturerRepository>(() => new ManufacturerRepository(repositoryContext));
            _mealRepository = new Lazy<IMealRepository>(() => new MealRepository(repositoryContext));
            _backupRepository = new Lazy<IBackupRepository>(() => new BackupRepository(repositoryContext));
            _companyRepository = new Lazy<ICompanyRepository>(() => new CompanyRepository(repositoryContext));
            _orderRepository = new Lazy<IOrderRepository>(() => new OrderRepository(repositoryContext));
        }

        public IMachineRepository Machine => _machineRepository.Value;

        public IMachineStatusRepository MachineStatus => _machineStatusRepository.Value;

        public IMachineTypeRepository MachineType => _machineTypeRepository.Value;

        public IMachineSettingsRepository MachineSettings => _machineSettingsRepository.Value;

        public IManufacturerRepository Manufacturer => _manufacturerRepository.Value;

        public IMealRepository Meal => _mealRepository.Value;

        public ICompanyRepository Company => _companyRepository.Value;

        public IOrderRepository Order => _orderRepository.Value;

        public IBackupRepository Backup => _backupRepository.Value;

        public async Task SaveAsync() => await _repositoryContext.SaveChangesAsync();
    }
}
