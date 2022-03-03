using System.Data;
using DigitalNetWeb.Data.Models;

namespace DigitalNetWeb.Data.ModelService
{
    public class DigimonSkillService
    {
        private List<DigimonSkill> ddb = new List<DigimonSkill>();
        private DBConnection? dataSQL;

        public DigimonSkillService(){}

        public List<DigimonSkill> searchDigimonSkills(int digimon)
        {
            if (dataSQL == null)
            {
                dataSQL = new DBConnection();
            }
            ddb.Clear();
            string query = "SELECT ds.id, ds.name, ds.[icon name], ds.digimon, ds.[evolution tree], e.name as [element], ds.cd, ds.ds, ds.sp, ds.lv, ds.[lv0 dmg], ds.[lv25 dmg], ds.skill_increase, ds.description, ds.position, ds.skill_buff, ds.skill_buff_name FROM digimon_skills as ds LEFT JOIN elements as e on ds.element = e.id";
            query += " WHERE ds.digimon_id=" + digimon + " ORDER BY position";
            dataSQL.pullSQL(query);
            DataTable myData = dataSQL.dataTable ?? new DataTable();
            foreach (DataRow row in myData.Rows)
            {
                DigimonSkill ds = new DigimonSkill();
                ds.Code = (int)row.Field<long>("id");
                ds.SkillName = (String?)row.Field<Object>("name");
                if (row.IsNull("icon name") || !File.Exists(Path.GetFullPath("wwwroot") + "/images/DigimonSkills/" + (String?)row.Field<Object>("icon name") + ".png")) { 
                    ds.IconLink = "/images/Kuramon.png"; 
                } else { 
                    ds.IconLink = "/images/DigimonSkills/" + (String?)row.Field<Object>("icon name") + ".png"; 
                }
                ds.DigimonName = (String?)row.Field<Object>("digimon");
                ds.DigimonEvoTree = (String?)row.Field<Object>("evolution tree");
                ds.Element = (String?)row.Field<Object>("element");
                ds.ElementIcon = "images/Elements/" + (String?)row.Field<Object>("element") + ".png";
                if (row.IsNull("cd")) { } else { ds.Cd = (int)row.Field<long>("cd"); }
                if (row.IsNull("ds")) { } else { ds.Ds = ((int)row.Field<long>("ds")); }
                if (row.IsNull("sp")) { } else { ds.Sp = ((int)row.Field<long>("sp")); }
                if (row.IsNull("lv")) { ds.Lv = ""; } else { ds.Lv = ((int)row.Field<long>("lv")).ToString(); }
                if (row.IsNull("lv0 dmg")) { ds.Dmglv0 = 0; } else { ds.Dmglv0 = (int)row.Field<long>("lv0 dmg"); }
                if (row.IsNull("lv25 dmg")) { ds.Dmglv25 = 0; } else { ds.Dmglv25 = (int)row.Field<long>("lv25 dmg"); }
                if (row.IsNull("skill_increase")) { ds.DmgIncrease = 0; } else { ds.DmgIncrease = (int)row.Field<long>("skill_increase"); }
                if (row.IsNull("description")) { } else { ds.Description = (String?)row.Field<Object>("description"); }
                if (row.IsNull("skill_buff")) { } else { ds.Effect = (String?)row.Field<Object>("skill_buff"); }
                if (row.IsNull("skill_buff_name")) { } else { ds.EffectName = (String?)row.Field<Object>("skill_buff_name"); }
                if (row.IsNull("position")) { } else { ds.position = (int)row.Field<long>("position"); }
                ddb.Add(ds);
            }
            return ddb;
        }
    }
}