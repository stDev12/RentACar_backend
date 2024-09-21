using App.DTO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.BL.Interfaces
{
    public interface IAuthManagement
    {
        public Task<UserDTO> RegisterUser(UserDTO userDTO);
        public Task<UserDTO> Login(UserLoginDTO userLoginDTO);
    }
}
