using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions
{
    public class MachineNotFoundException : NotFoundException
    {
        public MachineNotFoundException(Guid machineId)
            : base($"The machine with id: {machineId} doesn't exist in the database.")
        {
        }
    }
}
