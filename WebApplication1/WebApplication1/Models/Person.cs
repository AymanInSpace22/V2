using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class Person
{
    public int PersonId { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Email { get; set; }

    public string? PhoneNumber { get; set; }

    public int? Age { get; set; }

    public decimal? Height { get; set; }

    public decimal? Weight { get; set; }

    public DateOnly? Birthday { get; set; }
}
