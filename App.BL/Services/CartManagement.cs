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
    public class CartManagement : ICartManagement
    {
        private ICartRepository _cartRepository;
        private IMapper _mapper;

        public CartManagement(ICartRepository cartRepository, IMapper mapper)
        {
            _cartRepository = cartRepository;
            _mapper = mapper;
        }

        public async Task<List<CartDTO>> GetCart(Guid userId)
        {
            try
            {
                List<ShoppingCart> cart = await _cartRepository.GetCart(userId);
                return _mapper.Map<List<CartDTO>>(cart);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<CartDTO> AddToCart(CartDTO item)
        {
            try
            {
                item.Quantity = 1;
                ShoppingCart itemToAdd = await _cartRepository.AddToCart(_mapper.Map<ShoppingCart>(item));
                return _mapper.Map<CartDTO>(itemToAdd);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<CartDTO> UpdateCount(CartDTO item)
        {
            try
            {
                ShoppingCart updatedItem = await _cartRepository.UpdateCount(_mapper.Map<ShoppingCart>(item));
                return _mapper.Map<CartDTO>(updatedItem);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<CartDTO> RemoveFromCart(int id)
        {
            try
            {
                return _mapper.Map<CartDTO>(await _cartRepository.RemoveFromCart(id));
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
