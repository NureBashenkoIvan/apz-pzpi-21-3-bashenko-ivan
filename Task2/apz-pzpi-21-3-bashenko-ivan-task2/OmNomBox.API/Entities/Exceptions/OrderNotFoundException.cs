using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions
{
    public class OrderNotFoundException : NotFoundException
    {
        public OrderNotFoundException(Guid orderId)
            : base($"The order with id: {orderId} doesn't exist in the database.")
        {
        }
    }
}
