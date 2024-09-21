using App.BL.Interfaces;
using App.DAL.Entities;
using App.DAL.Interfaces;
using App.DTO.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.BL.Services
{
    public class OrdersManagement : IOrdersManagement
    {
        private IOrdersRepository _ordersRepository;
        private IMapper _mapper;

        public OrdersManagement(IOrdersRepository ordersRepository, IMapper mapper)
        {
            _ordersRepository = ordersRepository;
            _mapper = mapper;
        }

        public async Task<List<OrderDTO>> GetOrders(Guid userId)
        {
            try
            {
                List<Order> orders = await _ordersRepository.GetOrders(userId);
                return _mapper.Map<List<OrderDTO>>(orders);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<OrderDTO> CreateOrder(OrderDTO order)
        {
            try
            {
                Order orderRepository = _mapper.Map<Order>(order);
                Order orderRepo = await _ordersRepository.CreateOrder(orderRepository);
                OrderDTO orderDto = _mapper.Map<OrderDTO>(orderRepo);
                return orderDto;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<OrderDTO> DeleteOrder(int id)
        {
            try
            {
                return _mapper.Map<OrderDTO>(await _ordersRepository.DeleteOrder(id));
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
