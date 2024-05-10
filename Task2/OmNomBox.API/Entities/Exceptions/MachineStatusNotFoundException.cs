using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions
{
    public class MachineStatusNotFoundException : NotFoundException
    {
        public MachineStatusNotFoundException(Guid machineStatusId)
            : base($"The machine status with id: {machineStatusId} doesn't exist in the database.")
        {
        }
    }
}
