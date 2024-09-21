using App.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.DAL.Interfaces
{
    public interface IUsersRepository
    {
        public Task<User> GetUserById(string id);
        public Task<User> CreateUser(User user);
        public Task<User> UpdateUser(User user);
    }
}
