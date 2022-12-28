using System;
using System.Collections.Generic;

namespace TimeZoneAPI.Models;

public partial class CountryFlag
{
    public int Id { get; set; }

    public string Country { get; set; } = null!;

    public string Code { get; set; } = null!;

    public string Url { get; set; } = null!;
}
