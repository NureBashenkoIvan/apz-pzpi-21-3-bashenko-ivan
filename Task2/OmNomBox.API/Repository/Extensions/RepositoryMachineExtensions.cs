using Entities.Models;
using Repository.Extensions.Utility;
using System.Linq.Dynamic.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Extensions
{
    public static class RepositoryMachineExtensions
    {
        public static IQueryable<Machine> Search(this IQueryable<Machine> machines, string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
                return machines;
            var lowerCaseTerm = searchTerm.Trim().ToLower();
            return machines.Where(e => e.Name.ToLower().Contains(lowerCaseTerm));
        }

        public static IQueryable<Machine> Sort(this IQueryable<Machine> machines, string orderByQueryString)
        {
            if (string.IsNullOrWhiteSpace(orderByQueryString))
                return machines.OrderBy(e => e.Name);

            var orderQuery = OrderQueryBuilder.CreateOrderQuery<Machine>(orderByQueryString);

            if (string.IsNullOrWhiteSpace(orderQuery))
                return machines.OrderBy(e => e.Name);

            return machines.OrderBy(orderQuery);
        }
    }
}
