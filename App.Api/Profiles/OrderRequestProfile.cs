using App.Api.Models;
using App.DTO.Models;
using AutoMapper;

namespace App.Api.Profiles
{
    public class OrderRequestProfile : Profile
    {
        public OrderRequestProfile()
        {
            CreateMap<OrderRequest, OrderDTO>();

        }
    }
}
