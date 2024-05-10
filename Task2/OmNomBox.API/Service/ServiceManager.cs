using AutoMapper;
using Contracts;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Service.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class ServiceManager : IServiceManager
    {
        private readonly Lazy<IAuthenticationService> _authenticationService;
        private readonly Lazy<IUserService> _userService;
        private readonly Lazy<IOrderService> _orderService;
        private readonly Lazy<ICompanyService> _companyService;
        private readonly Lazy<IBackupService> _backupService;
        private readonly Lazy<IMealService> _mealService;
        private readonly Lazy<IManufacturerService> _manufacturerService;
        private readonly Lazy<IMachineService> _machineService;
        private readonly Lazy<IMachineTypeService> _machineTypeService;
        private readonly Lazy<IMachineStatusService> _machineStatusService;
        private readonly Lazy<IMachineSettingsService> _machineSettingsService;

        public ServiceManager(IRepositoryManager repositoryManager, ILoggerManager logger, IMapper mapper,
        UserManager<User> userManager, IConfiguration configuration)
        {
            _authenticationService = new Lazy<IAuthenticationService>(() =>
                new AuthenticationService(logger, mapper, userManager, configuration));
            _userService = new Lazy<IUserService>(() =>
                new UserService(logger, mapper, userManager, configuration));
            _backupService = new Lazy<IBackupService>(() => new BackupService(repositoryManager));
            _companyService = new Lazy<ICompanyService>(() => new CompanyService(repositoryManager, logger, mapper));
            _orderService = new Lazy<IOrderService>(() => new OrderService(repositoryManager, logger, mapper));
            _mealService = new Lazy<IMealService>(() => new MealService(repositoryManager, logger, mapper));
            _manufacturerService = new Lazy<IManufacturerService>(() => new ManufacturerService(repositoryManager, logger, mapper));
            _machineService = new Lazy<IMachineService>(() => new MachineService(repositoryManager, logger, mapper));
            _machineTypeService = new Lazy<IMachineTypeService>(() => new MachineTypeService(repositoryManager, logger, mapper));
            _machineStatusService = new Lazy<IMachineStatusService>(() => new MachineStatusService(repositoryManager, logger, mapper));
            _machineSettingsService = new Lazy<IMachineSettingsService>(() => new MachineSettingsService(repositoryManager, logger, mapper));
        }

        public IMachineService MachineService => _machineService.Value;

        public IMachineSettingsService MachineSettingsService => _machineSettingsService.Value;

        public IMachineTypeService MachineTypeService => _machineTypeService.Value;

        public IMachineStatusService MachineStatusService => _machineStatusService.Value;

        public IManufacturerService ManufacturerService => _manufacturerService.Value;

        public IMealService MealService => _mealService.Value;

        public ICompanyService CompanyService => _companyService.Value;

        public IBackupService BackupService => _backupService.Value;

        public IOrderService OrderService => _orderService.Value;

        public IUserService UserService => _userService.Value;

        public IAuthenticationService AuthenticationService => _authenticationService.Value;
    }
}
