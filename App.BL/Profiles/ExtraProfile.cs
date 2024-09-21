using App.DAL.Entities;
using App.DTO.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.BL.Profiles
{
    public class ExtraProfile : Profile
    {
        public ExtraProfile()
        {
            CreateMap<Extra, ExtraDTO>().ReverseMap();
        }
    }
}
