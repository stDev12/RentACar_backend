using App.Api.Models;
using App.DTO.Models;
using AutoMapper;

namespace App.Api.Profiles
{
    public class CartRequestProfile : Profile
    {
        public CartRequestProfile()
        {
            CreateMap<CartRequest, CartDTO>();
        }
    }
}
