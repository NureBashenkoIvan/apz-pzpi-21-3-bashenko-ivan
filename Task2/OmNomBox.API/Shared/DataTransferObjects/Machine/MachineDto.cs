using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
    public record MachineDto(Guid MachineId, string Name, string SerialNumber, Guid MachineTypeId, Guid MachineStatusId, Guid ManufacturerId,
        Guid CompanyId, string? Location, DateTime? InstallationDate, DateTime? LastMaintenanceDate);
}
