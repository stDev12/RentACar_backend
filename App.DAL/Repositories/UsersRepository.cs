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
    public class UsersRepository : IUsersRepository
    {
        private CarRentalContext db;

        public UsersRepository(CarRentalContext carRentalContext)
        {
            db = carRentalContext;
        }

        public async Task<User> GetUserById(string userId)
        {
            try
            {
                User? findUser = await db.Users.Include(u => u.Role).SingleOrDefaultAsync(u => u.Idnumber == userId);
                return findUser;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<User> CreateUser(User user)
        {
            try
            {
                await db.Users.AddAsync(user);
                await db.SaveChangesAsync();
                return user;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<User> UpdateUser(User user)
        {
            try
            {
                User? findUser = await db.Users.SingleOrDefaultAsync(u => u.Idnumber == user.Idnumber);
                if (findUser == null)
                    throw new InvalidOperationException("User nof found.");
                findUser.UserName = user.UserName;
                findUser.PhoneNumber = user.PhoneNumber;
                findUser.Email = user.Email;
                findUser.UserPassword = user.UserPassword;
                await db.SaveChangesAsync();
                return findUser;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
