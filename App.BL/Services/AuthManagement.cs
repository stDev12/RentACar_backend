using App.BL.Interfaces;
using App.DAL.Entities;
using App.DAL.Interfaces;
using App.DTO.Models;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace App.BL.Services
{
    public class AuthManagement : IAuthManagement
    {
        private IUsersRepository _usersRepository;
        private IMapper _mapper;
        IConfiguration _configuration;

        public AuthManagement(IUsersRepository usersRepository, IMapper mapper, IConfiguration configuration)
        {
            _usersRepository = usersRepository;
            _mapper = mapper;
            _configuration = configuration;
        }

        public async Task<UserDTO> RegisterUser(UserDTO userDTO)
        {
            try
            {
                userDTO.UserId = Guid.NewGuid();
                userDTO.RoleId = 2;
                User user = await _usersRepository.CreateUser(_mapper.Map<User>(userDTO));
                UserDTO userCreated = _mapper.Map<UserDTO>(user);
                return AuthenticateUser(userCreated);
            }
            catch (Exception)
            {

                throw;
            }

        }

        public async Task<UserDTO> Login(UserLoginDTO userLoginDTO)
        {
            UserDTO userById = _mapper.Map<UserDTO>(await _usersRepository.GetUserById(userLoginDTO.Idnumber));
            if (userById != null)
            {
                if (userById.UserPassword == userLoginDTO.UserPassword)
                    return AuthenticateUser(userById);
                else
                    throw new Exception("סיסמא לא נכונה");
            }
            throw new Exception("מספר זהות לא קיים");
        }

        private UserDTO AuthenticateUser(UserDTO user)
        {
            string jwtToken = GenerateJWTToken(user);
            TokenDTO token = new TokenDTO
            {
                TokenId = Guid.NewGuid(),
                UserId = user.UserId,
                TokenJwt = jwtToken,
                ExpiryDate = DateTime.Now.AddHours(12),
            };
            user.Tokens.Add(token);
            return user;
        }

        private string GenerateJWTToken(UserDTO user)
        {
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            byte[] key = Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]);
            List<Claim> claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Role, user.RoleName ?? "Customer")
            };
            JwtSecurityToken token = new JwtSecurityToken
                (
                claims: claims,
                expires: DateTime.Now.AddHours(12),
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                );

            string accassTokenValue = tokenHandler.WriteToken(token);
            return accassTokenValue;
        }
    }
}
