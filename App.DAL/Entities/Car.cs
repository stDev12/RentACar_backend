using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace App.DAL.Entities;

public partial class Car
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

    [JsonIgnore]
    public virtual ICollection<Rental> Rentals { get; set; } = new List<Rental>();

    public virtual ICollection<ShoppingCart> ShoppingCarts { get; set; } = new List<ShoppingCart>();
}
