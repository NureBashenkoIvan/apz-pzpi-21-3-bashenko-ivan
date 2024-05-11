using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface IServiceManager
    {
        IMachineService MachineService { get; }
        IMachineSettingsService MachineSettingsService { get; }
        IMachineTypeService MachineTypeService { get; }
        IMachineStatusService MachineStatusService { get; }
        IManufacturerService ManufacturerService { get; }
        IMealService MealService { get; }
        ICompanyService CompanyService { get; }
        IOrderService OrderService { get; }
        IBackupService BackupService { get; }
        IUserService UserService { get; }
        IAuthenticationService AuthenticationService { get; }
    }
}
