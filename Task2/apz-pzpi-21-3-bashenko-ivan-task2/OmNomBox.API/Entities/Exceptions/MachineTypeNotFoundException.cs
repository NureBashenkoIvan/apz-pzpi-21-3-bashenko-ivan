using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions
{
    public class MachineTypeNotFoundException : NotFoundException
    {
        public MachineTypeNotFoundException(Guid machineTypeId)
            : base($"The machine type with id: {machineTypeId} doesn't exist in the database.")
        {
        }
    }
}
