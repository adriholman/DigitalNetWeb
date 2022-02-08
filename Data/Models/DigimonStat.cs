namespace DigitalNetWeb.Data.Models
{
    public class DigimonStat : DBObject
    {
        public DigimonStat() { }
        public int DigimonID { get; set; }
        public string? Hp { get; set; }
        public string? Ds { get; set; }
        public string? At { get; set; }
        public string? AS { get; set; }
        public string? Ct { get; set; }
        public string? Ht { get; set; }
        public string? De { get; set; }
        public string? Bl { get; set; }
        public string? Ev { get; set; }
    }
}