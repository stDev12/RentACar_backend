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
    public class CarsRepository : ICarsRepository
    {
        private CarRentalContext db;

        public CarsRepository(CarRentalContext carRentalContext)
        {
            db = carRentalContext;
        }
        public async Task<List<Car>> GetCars()
        {
            try
            {
                return await db.Cars.ToListAsync();

            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<Car> GetCarById(int id)
        {
            try
            {
                Car? findCar = await db.Cars.SingleOrDefaultAsync(c => c.CarId == id);
                return findCar;
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
