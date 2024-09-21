using App.Api.Models;
using App.DTO.Models;
using AutoMapper;

namespace App.Api.Profiles
{
    public class UserRequestProfile : Profile
    {
        public UserRequestProfile()
        {
            CreateMap<UserRequest, UserDTO>();
            CreateMap<UserRegisterRequest, UserDTO>();
            CreateMap<UserUpdateRequest, UserDTO>();
        }
    }
}
