namespace DigitalNetWeb.Data.Models
{
    public class Digimon : DBObject
    {
        public Digimon() { }
        public string? DigimonLine { get; set; }
        public string? Stage { get; set; }
        public string? Rank { get; set; }
        public string? Attribute { get; set; }
        public string? ElementalAttribute { get; set; }
        public string? AttackerType { get; set; }
        public string? Family1 { get; set; }
        public string? Family2 { get; set; }
        public string? Family3 { get; set; }
        public string? Family4 { get; set; }
        public string? LvRequired { get; set; }
        public DigimonStat DigimonStat { get; set; }
        public List<DigimonSkill> DigimonSkills { get; set; }
    }
}