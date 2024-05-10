using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IRepositoryManager
    {
        ICompanyRepository Company { get; }
        IMachineRepository Machine { get; }
        IMachineStatusRepository MachineStatus { get; }
        IMachineTypeRepository MachineType { get; }
        IMachineSettingsRepository MachineSettings { get; }
        IManufacturerRepository Manufacturer { get; }
        IMealRepository Meal { get; }
        IOrderRepository Order { get; }
        IBackupRepository Backup { get; }

        Task SaveAsync();
    }
}
