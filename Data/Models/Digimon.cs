namespace DigitalNetWeb.Data.Models
{
    public class Digimon : DBObject
    {
        public Digimon() { }
        public string? DigimonLine { get; set; }
        public string? Stage { get; set; }
        public string? StageIcon { get; set; }
        public string? Rank { get; set; }
        public string? RankIcon { get; set; }
        public string? Attribute { get; set; }
        public string? AttributeIcon { get; set; }
        public string? Element { get; set; }
        public string? ElementIcon { get; set; }
        public string? Attacker { get; set; }
        public string? AttackerIcon { get; set; }
        public string? Family1 { get; set; }
        public string? Family2 { get; set; }
        public string? Family3 { get; set; }
        public string? Family4 { get; set; }
        public string? LvRequired { get; set; }
        public DigimonStat DigimonStat { get; set; }
        public List<DigimonSkill> DigimonSkills { get; set; }
        public List<Item> UnlockedItems {get;set;}
        public List<Item> EvolveItems {get;set;}
        public List<Item> RideItems {get;set;}
        public List<DRequired> DRequired {get; set;}
    }
}