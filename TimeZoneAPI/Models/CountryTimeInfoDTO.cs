namespace TimeZoneAPI.Models
{
    public class CountryTimeInfoDTO
    {
        public string? CountryCode { get; set; }
        public string? CountryName { get; set; }
        public IEnumerable<TimeZoneDTO>? timeZones { get; set; }
    }
}
