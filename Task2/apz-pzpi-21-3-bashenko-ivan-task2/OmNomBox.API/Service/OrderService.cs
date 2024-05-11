using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
using Service.Contracts;
using Shared.DataTransferObjects;
using Shared.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    internal sealed class OrderService : IOrderService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public OrderService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<IEnumerable<OrderDto>> GetAllOrdersAsync(OrderParameters orderParameters, bool trackChanges)
        {
            var orders = await _repository.Order.GetAllOrdersAsync(orderParameters, trackChanges);

            var ordersDto = _mapper.Map<IEnumerable<OrderDto>>(orders);

            return ordersDto;
        }

        public async Task<IEnumerable<OrderDto>> GetAllOrdersForUserAsync(string userId, OrderParameters orderParameters,
            bool trackChanges)
        {
            var orders = await _repository.Order.GetAllOrdersForUserAsync(userId, orderParameters,
                trackChanges);

            var ordersDto = _mapper.Map<IEnumerable<OrderDto>>(orders);

            return ordersDto;
        }

        public async Task<OrderDto> GetOrderAsync(Guid id, bool trackChanges)
        {
            var order = await GetOrderAndCheckIfItExists(id, trackChanges);

            var orderDto = _mapper.Map<OrderDto>(order);

            return orderDto;
        }

        public async Task<OrderDto> CreateOrderAsync(string userId, CreateUpdateOrderDto order)
        {
            var orderEntity = _mapper.Map<Order>(order);
            orderEntity.UserId = userId;
            orderEntity.OrderDate = DateTime.Now;
            _repository.Order.CreateOrder(orderEntity);
            await _repository.SaveAsync();

            var orderToReturn = _mapper.Map<OrderDto>(orderEntity);
            return orderToReturn;
        }

        public async Task DeleteOrderAsync(Guid id, bool trackChanges)
        {
            var order = await GetOrderAndCheckIfItExists(id, trackChanges);

            _repository.Order.DeleteOrder(order);

            await _repository.SaveAsync();
        }

        public async Task UpdateOrderAsync(Guid orderId, CreateUpdateOrderDto orderForUpdate, bool trackChanges)
        {
            var order = await GetOrderAndCheckIfItExists(orderId, trackChanges);

            _mapper.Map(orderForUpdate, order);
            await _repository.SaveAsync();
        }

        private async Task<Order> GetOrderAndCheckIfItExists(Guid id, bool trackChanges)
        {
            var order = await _repository.Order.GetOrderAsync(id, trackChanges);
            if (order is null)
                throw new OrderNotFoundException(id);

            return order;
        }
    }
}
