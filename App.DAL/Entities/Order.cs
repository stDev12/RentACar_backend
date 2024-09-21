using System;
using System.Collections.Generic;

namespace App.DAL.Entities;

public partial class Order
{
    public int OrderId { get; set; }

    public DateTime OrderDate { get; set; }

    public Guid UserId { get; set; }

    public decimal TotalAmount { get; set; }

    public virtual User User { get; set; } = null!;

    public virtual ICollection<Rental> Rentals { get; set; } = new List<Rental>();
}
