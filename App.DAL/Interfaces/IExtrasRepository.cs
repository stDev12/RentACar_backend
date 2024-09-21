using App.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.DAL.Interfaces
{
    public interface IExtrasRepository
    {
        public Task<List<Extra>> GetExtras();
        public Task<Extra> ToggleExtraInCart(int extraId, int cartItemId);
    }
}
