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
    public class ExtrasManagement : IExtrasManagement
    {
        private IExtrasRepository _extrasRepository;
        private IMapper _mapper;

        public ExtrasManagement(IExtrasRepository extrasRepository, IMapper mapper)
        {
            _extrasRepository = extrasRepository;
            _mapper = mapper;
        }

        public async Task<List<ExtraDTO>> GetAllExtras()
        {
            try
            {
                List<Extra> extras = await _extrasRepository.GetExtras();
                List<ExtraDTO> extraDTOs = _mapper.Map<List<ExtraDTO>>(extras);
                return extraDTOs;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public async Task<ExtraDTO> ToggleExtraInCart(int extraId, int cartItemId)
        {
            try
            {
                Extra updatedExtra = await _extrasRepository.ToggleExtraInCart(extraId, cartItemId);
                return _mapper.Map<ExtraDTO>(updatedExtra);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
