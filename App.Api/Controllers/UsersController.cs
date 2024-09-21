using App.Api.Models;
using App.BL.Interfaces;
using App.BL.Services;
using App.DTO.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace App.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IUsersManagement _usersManagement;
        private IMapper _mapper;

        public UsersController(IUsersManagement usersMangement, IMapper mapper)
        {
            _usersManagement = usersMangement;
            _mapper = mapper;
        }

        //GET: api/Users/123456789
        [HttpGet("{id}")]
        public async Task<ActionResult<UserDTO>> GetUser(string id)
        {
            try
            {
                return Ok(await _usersManagement.GetUser(id));
            }
            catch (Exception)
            {

                throw;
            }

        }

        //GET: api/Users
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<UserDTO>> CreateUser([FromBody] UserRequest user)
        {
            try
            {
                return Ok(await _usersManagement.CreateUser(_mapper.Map<UserDTO>(user)));
            }
            catch (Exception)
            {

                throw;
            }
        }

        //PUT: api/Users
        [HttpPut]
        public async Task<ActionResult<UserDTO>> UpdateUser([FromBody] UserUpdateRequest user)
        {
            try
            {
                return Ok(await _usersManagement.UpdateUser(_mapper.Map<UserDTO>(user)));
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
