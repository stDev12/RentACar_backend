using System;
using System.Collections.Generic;

namespace App.DAL.Entities;

public partial class Rental
{
    public int RentalId { get; set; }

    public int CarId { get; set; }

    public int CountDays { get; set; }

    public virtual Car Car { get; set; } = null!;

    public virtual ICollection<Extra> Extras { get; set; } = new List<Extra>();

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
