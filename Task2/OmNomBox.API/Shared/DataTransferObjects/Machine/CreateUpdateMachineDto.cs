using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
    public record CreateUpdateMachineDto(string Name, string SerialNumber, Guid MachineTypeId, Guid MachineStatusId, Guid ManufacturerId,
        string? Location, DateTime? InstallationDate, DateTime? LastMaintenanceDate);
}
