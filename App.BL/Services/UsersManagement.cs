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
    public class UsersManagement : IUsersManagement
    {
        private IUsersRepository _usersRepository;
        private IMapper _mapper;

        public UsersManagement(IUsersRepository usersRepository, IMapper mapper)
        {
            _usersRepository = usersRepository;
            _mapper = mapper;
        }

        public async Task<UserDTO> GetUser(string id)
        {
            try
            {
                User user = await _usersRepository.GetUserById(id);
                return _mapper.Map<UserDTO>(user);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<UserDTO> CreateUser(UserDTO user)
        {
            try
            {
                user.UserId = Guid.NewGuid();
                User newUser = await _usersRepository.CreateUser(_mapper.Map<User>(user));

                return _mapper.Map<UserDTO>(newUser);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<UserDTO> UpdateUser(UserDTO user)
        {
            try
            {
                User updatedUser = await _usersRepository.UpdateUser(_mapper.Map<User>(user));
                return _mapper.Map<UserDTO>(updatedUser);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
