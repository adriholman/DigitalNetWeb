namespace DigitalNetWeb.Data.Models
{
    public class Tamer : DBObject
    {
        public Tamer(){}
        public string? Nickname { get; set; }
        public string? Avaible { get; set; }
        public string? ASkillName { get; set; }
        public string? ASkillCD { get; set; }
        public string? PSkill1N { get; set; }
        public string? PSkill1B { get; set; }
        public string? PSkill1A { get; set; }
        public string? PSkill2N { get; set; }
        public string? PSkill2B { get; set; }
        public string? PSkill2A { get; set; }
        public int AT { get; set; }
        public int DE { get; set; }
        public int HP { get; set; }
        public int DS { get; set; }
    }
}