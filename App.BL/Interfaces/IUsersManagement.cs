using App.DTO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.BL.Interfaces
{
    public interface IUsersManagement
    {
        public Task<UserDTO> GetUser(string id);
        public Task<UserDTO> CreateUser(UserDTO userDTO);
        public Task<UserDTO> UpdateUser(UserDTO user);
    }
}
