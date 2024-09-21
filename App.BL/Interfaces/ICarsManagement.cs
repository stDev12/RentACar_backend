using App.DTO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.BL.Interfaces
{
    public interface ICarsManagement
    {
        public Task<List<CarDTO>> GetAllCars();
        public Task<CarDTO> GetCarById(int id);
    }
}
