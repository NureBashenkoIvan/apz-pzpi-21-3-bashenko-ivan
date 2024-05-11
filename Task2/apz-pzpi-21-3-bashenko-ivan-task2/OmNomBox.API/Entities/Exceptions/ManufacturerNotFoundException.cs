using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions
{
    public class ManufacturerNotFoundException : NotFoundException
    {
        public ManufacturerNotFoundException(Guid manufacturerId)
            : base($"The manufacturer with id: {manufacturerId} doesn't exist in the database.")
        {
        }
    }
}
