using App.Api.Models;
using App.BL.Interfaces;
using App.DTO.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace App.Api.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CartController : ControllerBase
    {
        private ICartManagement _cartManagement;
        private IMapper _mapper;

        public CartController(ICartManagement cartManagement, IMapper mapper)
        {
            _cartManagement = cartManagement;
            _mapper = mapper;
        }

        //GET: api/Cart
        [HttpGet]
        public async Task<ActionResult<List<CartDTO>>> GetCartByUser(Guid userId)
        {
            try
            {
                return Ok(await _cartManagement.GetCart(userId));
            }
            catch (Exception)
            {

                throw;
            }

        }

        //POST: api/Cart
        [HttpPost]
        public async Task<ActionResult<CartDTO>> AddItemToCart([FromBody] CartRequest item)
        {
            try
            {
                return Ok(await _cartManagement.AddToCart(_mapper.Map<CartDTO>(item)));
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        //PUT: api/Cart
        [HttpPut]
        public async Task<ActionResult<CartDTO>> UpdateCount([FromBody] CartDTO item)
        {
            try
            {
                return Ok(await _cartManagement.UpdateCount(item));
            }
            catch (Exception)
            {

                throw;
            }
        }

        //DELETE: api/Cart/101
        [HttpDelete("{id}")]
        public async Task<ActionResult<CartDTO>> RemoveItemFromCart(int id)
        {
            try
            {
                return Ok(await _cartManagement.RemoveFromCart(id));
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
