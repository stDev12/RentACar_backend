using App.Api.Models;
using App.BL.Interfaces;
using App.DTO.Models;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace App.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private IOrdersManagement _ordersManagement;
        private IMapper _mapper;

        public OrdersController(IOrdersManagement ordersManagement, IMapper mapper)
        {
            _ordersManagement = ordersManagement;
            _mapper = mapper;
        }

        //GET: api/Orders
        [HttpGet]
        public async Task<ActionResult<List<OrderDTO>>> GetOrdersByUser(Guid userId)
        {
            try
            {
                return Ok(await _ordersManagement.GetOrders(userId));
            }
            catch (Exception)
            {

                throw;
            }

        }

        //POST :api/Orders
        [HttpPost]
        public async Task<ActionResult<OrderDTO>> CreateOrder([FromBody] OrderRequest order)
        {
            try
            {
                OrderDTO orderDto = _mapper.Map<OrderDTO>(order);
                orderDto.Rentals = _mapper.Map<List<RentalDTO>>(order.Rentals);
                return Ok(await _ordersManagement.CreateOrder(orderDto));
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        //DELETE: api/Orders/12345
        [HttpDelete("{id}")]
        public async Task<ActionResult<OrderDTO>> DeleteOrder(int id)
        {
            try
            {
                return Ok(await _ordersManagement.DeleteOrder(id));
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
