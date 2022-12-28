using System;
using System.Collections.Generic;

namespace TimeZoneAPI.Models;

public partial class CountryCapital
{
    public int CapitalId { get; set; }

    public string Country { get; set; } = null!;

    public string Capital { get; set; } = null!;
}
