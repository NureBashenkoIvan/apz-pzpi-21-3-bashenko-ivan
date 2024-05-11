using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.RequestFeatures
{
    public class MachineParameters : RequestParameters
    {
        public MachineParameters() => OrderBy = "serialNumber";

        public string? SearchTerm { get; set; }
    }
}
