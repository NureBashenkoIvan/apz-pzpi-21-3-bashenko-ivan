using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions
{
   public class MachineSettingsNotFoundException : NotFoundException
    {
        public MachineSettingsNotFoundException(Guid machineSettingsId)
            : base($"The machine settings with id: {machineSettingsId} doesn't exist in the database.")
        {
        }
    }
}
