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
    public class OrdersRepository : IOrdersRepository
    {
        private CarRentalContext db;

        public OrdersRepository(CarRentalContext carRentalContext)
        {
            db = carRentalContext;
        }

        public async Task<List<Order>> GetOrders(Guid userId)
        {
            try
            {
                return await db.Orders.Include(o => o.Rentals).ThenInclude(r => r.Car).Where(o => o.UserId == userId).ToListAsync();

            }
            catch (Exception)
            {

                throw;
            }

        }

        public async Task<Order> CreateOrder(Order order)
        {
            try
            {
                await db.Orders.AddAsync(order);
                await db.SaveChangesAsync();
                return order;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public async Task<Order> DeleteOrder(int id)
        {
            try
            {
                Order? findOrder = await db.Orders.SingleOrDefaultAsync(o => o.OrderId == id);
                db.Orders.Remove(findOrder);
                await db.SaveChangesAsync();
                return findOrder;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
