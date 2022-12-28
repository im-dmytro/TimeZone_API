namespace TimeZoneAPI
{
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Capital { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public string TimeZone { get; set; } = string.Empty;
        public string GmtOffset { get; set; } = string.Empty;
        public string FlagUrl { get; set; } = string.Empty;
    }
}
