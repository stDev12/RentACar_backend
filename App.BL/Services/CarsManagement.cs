using App.BL.Interfaces;
using App.DAL.Entities;
using App.DAL.Interfaces;
using App.DTO.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.BL.Services
{
    public class CarsManagement : ICarsManagement
    {
        private ICarsRepository _carsRepository;
        private IMapper _mapper;

        public CarsManagement(ICarsRepository carsRepository, IMapper mapper)
        {
            _carsRepository = carsRepository;
            _mapper = mapper;
        }
        public async Task<List<CarDTO>> GetAllCars()
        {
            try
            {
                List<Car> cars = await _carsRepository.GetCars();
                return _mapper.Map<List<CarDTO>>(cars);
            }
            catch (Exception)
            {

                throw;
            }

        }

        public async Task<CarDTO> GetCarById(int id)
        {
            try
            {
                Car car = await _carsRepository.GetCarById(id);
                return _mapper.Map<CarDTO>(car);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
