using Shared.DataTransferObjects;
using Shared.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface IOrderService
    {
        Task<IEnumerable<OrderDto>> GetAllOrdersAsync(OrderParameters orderParameters, bool trackChanges);
        Task<IEnumerable<OrderDto>> GetAllOrdersForUserAsync(string userId, OrderParameters orderParameters, bool trackChanges);
        Task<OrderDto> GetOrderAsync(Guid id, bool trackChanges);
        Task<OrderDto> CreateOrderAsync(string userId, CreateUpdateOrderDto order);
        Task DeleteOrderAsync(Guid id, bool trackChanges);
        Task UpdateOrderAsync(Guid orderId, CreateUpdateOrderDto orderForUpdate, bool trackChanges);
    }
}
