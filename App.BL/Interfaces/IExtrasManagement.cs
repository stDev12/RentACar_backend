using App.DTO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.BL.Interfaces
{
    public interface IExtrasManagement
    {
        public Task<List<ExtraDTO>> GetAllExtras();
        public Task<ExtraDTO> ToggleExtraInCart(int extraId, int cartItemId);
    }
}
