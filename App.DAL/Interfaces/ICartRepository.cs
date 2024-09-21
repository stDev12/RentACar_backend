using App.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.DAL.Interfaces
{
    public interface ICartRepository
    {
        public Task<List<ShoppingCart>> GetCart(Guid userId);
        public Task<ShoppingCart> AddToCart(ShoppingCart item);
        public Task<ShoppingCart> UpdateCount(ShoppingCart item);
        public Task<ShoppingCart> RemoveFromCart(int id);
    }
}
