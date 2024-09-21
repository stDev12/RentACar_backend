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
    public class AuthController : ControllerBase
    {
        private IAuthManagement _authManagement;
        private IMapper _mapper;

        public AuthController(IAuthManagement authManagement, IMapper mapper)
        {
            _authManagement = authManagement;
            _mapper = mapper;
        }

        //POST: api/Auth/signUp
        [HttpPost("signUp")]
        public async Task<ActionResult<UserDTO>> RegisterUser([FromBody] UserRegisterRequest userRegisterRequest)
        {
            try
            {
                return Ok(await _authManagement.RegisterUser(_mapper.Map<UserDTO>(userRegisterRequest)));
            }
            catch (Exception)
            {

                throw;
            }

        }

        //POST: api/Auth/login
        [HttpPost("login")]
        public async Task<ActionResult<UserDTO>> Login([FromBody] UserLoginDTO userLoginDTO)
        {
            try
            {
                return Ok(await _authManagement.Login(userLoginDTO));
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
