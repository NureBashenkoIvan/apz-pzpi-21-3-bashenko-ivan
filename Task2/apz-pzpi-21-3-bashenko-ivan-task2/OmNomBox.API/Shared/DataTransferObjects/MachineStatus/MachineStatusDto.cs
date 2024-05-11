using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
    public record MachineStatusDto(Guid MachineStatusId, string Name, string Description);
}
