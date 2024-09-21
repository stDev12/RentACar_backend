using App.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.DTO.Models
{
    public class RentalDTO
    {
        public int RentalId { get; set; }

        public int CarId { get; set; }

        public int CountDays { get; set; }

        public virtual Car Car { get; set; } = null!;

        public virtual ICollection<Extra> Extras { get; set; } = new List<Extra>();
    }
}
