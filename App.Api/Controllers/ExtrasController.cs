using App.BL.Interfaces;
using App.DTO.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace App.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExtrasController : ControllerBase
    {
        private IExtrasManagement _extrasManagement;

        public ExtrasController(IExtrasManagement extrasManagement)
        {
            _extrasManagement = extrasManagement;
        }

        //GET: api/Extras
        [HttpGet]
        public async Task<ActionResult<List<ExtraDTO>>> GetAllExtras()
        {
            try
            {
                return Ok(await _extrasManagement.GetAllExtras());
            }
            catch (Exception)
            {

                throw;
            }

        }

        //PUT: api/Extras/5
        [HttpPut("{extraId}")]
        public async Task<ActionResult<ExtraDTO>> ToggleExtraInCartItem(int extraId, [FromBody] int cartItemId)
        {
            try
            {
                return Ok(await _extrasManagement.ToggleExtraInCart(extraId, cartItemId));
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
