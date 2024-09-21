using App.BL.Interfaces;
using App.DTO.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace App.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private ICarsManagement _carsManagement;

        public CarsController(ICarsManagement carsManagement)
        {
            _carsManagement = carsManagement;
        }

        //GET: api/Cars
        [HttpGet]
        public async Task<ActionResult<List<CarDTO>>> GetAllCars()
        {
            try
            {
                return Ok(await _carsManagement.GetAllCars());
            }
            catch (Exception)
            {

                throw;
            }

        }

        //GET: api/Cars/101
        [HttpGet("{id}")]
        public async Task<ActionResult<CarDTO>> GetCarById(int id)
        {
            try
            {
                return Ok(await _carsManagement.GetCarById(id));
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
