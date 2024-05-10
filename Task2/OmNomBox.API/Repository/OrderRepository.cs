using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Extensions;
using Shared.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class OrderRepository : RepositoryBase<Order>, IOrderRepository
    {
        public OrderRepository(RepositoryContext repositoryContext)
        : base(repositoryContext)
        {
        }

        public async Task<IEnumerable<Order>> GetAllOrdersAsync(OrderParameters orderParameters, bool trackChanges) =>
        await FindAll(trackChanges)
            .Sort(orderParameters.OrderBy)
            .Skip((orderParameters.PageNumber - 1) * orderParameters.PageSize)
            .Take(orderParameters.PageSize)
            .ToListAsync();

        public async Task<IEnumerable<Order>> GetAllOrdersForUserAsync(string userId, OrderParameters orderParameters, bool trackChanges) =>
        await FindByCondition(o => o.UserId.Equals(userId), trackChanges)
            .Sort(orderParameters.OrderBy)
            .Skip((orderParameters.PageNumber - 1) * orderParameters.PageSize)
            .Take(orderParameters.PageSize)
            .ToListAsync();

        public async Task<Order> GetOrderAsync(Guid orderId, bool trackChanges) =>
        await FindByCondition(o => o.OrderId.Equals(orderId), trackChanges)
            .SingleOrDefaultAsync();

        public void CreateOrder(Order order) => Create(order);

        public void DeleteOrder(Order order) => Delete(order);
    }
}
