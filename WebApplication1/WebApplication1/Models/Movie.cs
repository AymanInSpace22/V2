using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class Movie
{
    public int MovieId { get; set; }

    public string Title { get; set; } = null!;

    public int? ReleaseYear { get; set; }

    public string? Genre { get; set; }

    public decimal? Rating { get; set; }

    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();
}
