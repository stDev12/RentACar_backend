using App.DTO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.BL.Interfaces
{
    public interface ICartManagement
    {
        public Task<List<CartDTO>> GetCart(Guid userId);
        public Task<CartDTO> AddToCart(CartDTO item);
        public Task<CartDTO> UpdateCount(CartDTO item);
        public Task<CartDTO> RemoveFromCart(int id);
    }
}
