using Entities.Models;
using Shared.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IOrderRepository
    {
        Task<IEnumerable<Order>> GetAllOrdersAsync(OrderParameters orderParameters, bool trackChanges);
        Task<IEnumerable<Order>> GetAllOrdersForUserAsync(string userId, OrderParameters orderParameters, bool trackChanges);
        Task<Order> GetOrderAsync(Guid orderId, bool trackChanges);
        void CreateOrder(Order order);
        void DeleteOrder(Order order);
    }
}
