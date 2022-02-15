namespace DigitalNetWeb.Data.Models
{
    public class DigimonSkill : DBObject
    {
        public DigimonSkill() { }
        public string? DigimonName { get; set; }
        public string? DigimonEvoTree { get; set; }
        public string? SkillName { get; set; }
        public int Cd { get; set; }
        public int Ds { get; set; }
        public string? Element { get; set; }
        public int Dmglv0 { get; set; }
        public int Dmglv10 { get; set; }
        public int Dmglv25 { get; set; }
        public int DmgIncrease { get; set; }
        public int Sp { get; set; }
        public string? Lv { get; set; }
        public string? Effect { get; set; }
        public string? EffectName { get; set; }
        public int position { get; set; }
        /*
        public string calculateSkill(int sklv)
        {
            string lv = "";
            if (!Dmglv0.Equals("") & !Dmglv10.Equals(""))
            {
                double skillInc = (int.Parse(Dmglv0) - int.Parse(Dmglv10)) / 9;
                double lvSK = int.Parse(Dmglv0) + (skillInc * (sklv - 1));
                lv = lvSK.ToString();
            }
            return lv;
        }

        public string newCalculateSkill(int sklv)
        {
            string lv = "";
            if (!Dmglv0.Equals("") & !Dmglv10.Equals(""))
            {
                double skillInc = (int.Parse(Dmglv0) - int.Parse(Dmglv25)) / 25;
                double lvSK = int.Parse(Dmglv0) + (skillInc * (sklv - 1));
                lv = lvSK.ToString();
            }
            return lv;
        }
        */
    }
}