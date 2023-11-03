using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class Review
{
    public int ReviewId { get; set; }

    public int? MovieId { get; set; }

    public string ReviewerName { get; set; } = null!;

    public DateOnly? ReviewDate { get; set; }

    public int? Rating { get; set; }

    public string? Comment { get; set; }

    public virtual Movie? Movie { get; set; }
}
