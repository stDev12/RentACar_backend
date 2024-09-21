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
    public class ExtrasRepository : IExtrasRepository
    {
        private CarRentalContext db;

        public ExtrasRepository(CarRentalContext carRentalContext)
        {
            db = carRentalContext;
        }
        public async Task<List<Extra>> GetExtras()
        {
            try
            {
                return await db.Extras.ToListAsync();

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Extra> ToggleExtraInCart(int extraId, int cartItemId)
        {
            try
            {
                var extra = await db.Extras
                    .Include(e => e.CartItems)
                    .SingleOrDefaultAsync(e => e.ExtraId == extraId);
                if (extra == null)
                    throw new Exception();
                var cartItem = await db.ShoppingCarts.SingleOrDefaultAsync(s => s.CartItemId == cartItemId);
                if (cartItem == null)
                    throw new Exception();
                if (extra.CartItems.Contains(cartItem))
                    extra.CartItems.Remove(cartItem);
                else
                    extra.CartItems.Add(cartItem);
                await db.SaveChangesAsync();
                return extra;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
