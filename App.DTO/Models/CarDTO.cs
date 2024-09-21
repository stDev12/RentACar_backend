using App.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.DTO.Models
{
    public class CarDTO
    {
        public int CarId { get; set; }

        public string CarName { get; set; } = null!;

        public int? CategoryId { get; set; }

        public string? CarType { get; set; }

        public int? NumberOfPlaces { get; set; }

        public decimal? Rating { get; set; }

        public int Price { get; set; }

        public string? Info { get; set; }

        public string ImagePath { get; set; } = null!;

        public virtual Category? Category { get; set; }

    }
}
