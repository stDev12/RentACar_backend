using App.DTO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.BL.Interfaces
{
    public interface IOrdersManagement
    {
        public Task<List<OrderDTO>> GetOrders(Guid userId);
        public Task<OrderDTO> CreateOrder(OrderDTO order);
        public Task<OrderDTO> DeleteOrder(int id);
    }
}
