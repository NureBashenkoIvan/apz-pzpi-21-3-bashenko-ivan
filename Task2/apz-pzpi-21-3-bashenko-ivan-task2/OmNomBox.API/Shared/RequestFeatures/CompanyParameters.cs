using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.RequestFeatures
{
    public class CompanyParameters : RequestParameters
    {
        public CompanyParameters() => OrderBy = "userId";

        public string? SearchTerm { get; set; }
    }
}
