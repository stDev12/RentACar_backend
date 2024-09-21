using System;
using System.Collections.Generic;

namespace App.DAL.Entities;

public partial class ShoppingCart
{
    public int CartItemId { get; set; }

    public Guid UserId { get; set; }

    public int CarId { get; set; }

    public int Quantity { get; set; }

    public virtual Car Car { get; set; } = null!;

    public virtual User User { get; set; } = null!;

    public virtual ICollection<Extra> Extras { get; set; } = new List<Extra>();
}
