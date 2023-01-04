namespace TimeZoneAPI.Models
{
    public class CountryInfoDTO
    {
        public string Id { get; set; } = null!;
        public string Country { get; set; } = null!;


        public string Capital { get; set; } = null!;
        public string FlagUrl { get; set; } = null!;
        public IEnumerable<TimeZoneDTO>? CountryTimeZones { get; set; }
    }
}
