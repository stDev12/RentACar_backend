using System;
using System.Collections.Generic;

namespace App.DAL.Entities;

public partial class User
{
    public Guid UserId { get; set; }

    public string UserName { get; set; } = null!;

    public string Idnumber { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;

    public string UserPassword { get; set; } = null!;

    public string LicenseNumber { get; set; } = null!;

    public int Age { get; set; }

    public DateTime CreatedAt { get; set; }

    public int RoleId { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual Role Role { get; set; } = null!;

    public virtual ICollection<ShoppingCart> ShoppingCarts { get; set; } = new List<ShoppingCart>();

    public virtual ICollection<Token> Tokens { get; set; } = new List<Token>();
}
