namespace DigitalNetWeb.Data.Models
{
    public class DigimonSeal : DBObject
    {
        public DigimonSeal() { }
        public string? sealBonus { get; set; }
        public string? stage { get; set; }
        public string? stat { get; set; }
        public string? b1 { get; set; }
        public string? b50 { get; set; }
        public string? b200 { get; set; }
        public string? b500 { get; set; }
        public string? b1000 { get; set; }
        public string? b3000 { get; set; }

    }
}