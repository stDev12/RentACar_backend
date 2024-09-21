using System;
using System.Collections.Generic;

namespace App.DAL.Entities;

public partial class Extra
{
    public int ExtraId { get; set; }

    public string ExtraName { get; set; } = null!;

    public decimal Price { get; set; }

    public virtual ICollection<ShoppingCart> CartItems { get; set; } = new List<ShoppingCart>();

    public virtual ICollection<Rental> Rentals { get; set; } = new List<Rental>();
}
