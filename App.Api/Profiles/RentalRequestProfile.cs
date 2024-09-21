using App.Api.Models;
using App.DAL.Entities;
using App.DTO.Models;
using AutoMapper;

namespace App.Api.Profiles
{
    public class RentalRequestProfile : Profile
    {
        public RentalRequestProfile()
        {
            CreateMap<RentalRequest, RentalDTO>()
            .ForMember(dest => dest.CarId, opt => opt.MapFrom(src => src.CarId));
        }
    }
}
