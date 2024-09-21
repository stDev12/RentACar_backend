using App.DAL.DataContext;
using App.DAL.Entities;
using App.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.DAL.Repositories
{
    public class CartRepository : ICartRepository
    {
        private CarRentalContext db;

        public CartRepository(CarRentalContext carRentalContext)
        {
            db = carRentalContext;
        }

        public async Task<List<ShoppingCart>> GetCart(Guid userId)
        {
            try
            {
                return await db.ShoppingCarts.Include(c => c.Car).Include(c => c.Extras).Where(c => c.UserId == userId).ToListAsync();

            }
            catch (Exception)
            {

                throw;
            }

        }

        public async Task<ShoppingCart> AddToCart(ShoppingCart item)
        {
            try
            {
                await db.ShoppingCarts.AddAsync(item);
                await db.SaveChangesAsync();
                return item;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public async Task<ShoppingCart> UpdateCount(ShoppingCart item)
        {
            try
            {
                ShoppingCart? findItem = await db.ShoppingCarts.SingleOrDefaultAsync(i => i.CartItemId == item.CartItemId);
                if (findItem == null)
                    throw new InvalidOperationException("Item nof found.");
                findItem.Quantity = item.Quantity;
                await db.SaveChangesAsync();
                return findItem;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<ShoppingCart> RemoveFromCart(int id)
        {
            try
            {
                ShoppingCart? findItem = await db.ShoppingCarts.Include(s => s.Extras).SingleOrDefaultAsync(i => i.CartItemId == id);
                if (findItem == null)
                    throw new InvalidOperationException("Item nof found.");
                findItem.Extras = null;
                db.ShoppingCarts.Remove(findItem);
                await db.SaveChangesAsync();
                return findItem;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
