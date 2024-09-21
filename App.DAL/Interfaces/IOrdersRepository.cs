using App.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.DAL.Interfaces
{
    public interface IOrdersRepository
    {
        public Task<List<Order>> GetOrders(Guid userId);
        public Task<Order> CreateOrder(Order order);
        public Task<Order> DeleteOrder(int id);
    }
}
