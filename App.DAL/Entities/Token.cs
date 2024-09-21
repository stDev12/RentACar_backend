using System;
using System.Collections.Generic;

namespace App.DAL.Entities;

public partial class Token
{
    public Guid TokenId { get; set; }

    public Guid UserId { get; set; }

    public string TokenJwt { get; set; } = null!;

    public DateTime ExpiryDate { get; set; }

    public virtual User User { get; set; } = null!;
}
