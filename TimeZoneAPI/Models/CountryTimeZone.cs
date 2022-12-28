using System;
using System.Collections.Generic;

namespace TimeZoneAPI.Models;

public partial class CountryTimeZone
{
    public int TimeZoneId { get; set; }

    public string? Country { get; set; }

    public string? CountryCode { get; set; }

    public string? TimeZoneName { get; set; }

    public string? GmtOffset { get; set; }
}
