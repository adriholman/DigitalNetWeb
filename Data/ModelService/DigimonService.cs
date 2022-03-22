using System.Data;
using DigitalNetWeb.Data.Models;

namespace DigitalNetWeb.Data.ModelService
{
    public class DigimonService
    {
        private List<Digimon> ddb = new List<Digimon>();
        private DBConnection? dataSQL;
        public DigimonService() { }
        public List<Digimon> SearchDigimon(string text)
        {
            if (dataSQL == null)
            {
                dataSQL = new DBConnection();
            }
            ddb.Clear();
            string query = "SELECT * FROM digimon_view where (dub_name like '%" + text + "%' or korean_name like '%" + text + "%' or other_names like '%" + text + "%' or " +
                           "attacker_type like '%" + text + "%' or digimon_attribute like '%" + text + "%' or element like '%" + text + "%' or " + 
                           "stage like '%" + text + "%' or digimon_rank like '%" + text + "%')";
            dataSQL.pullSQL(query);
            DataTable myData = dataSQL.dataTable ?? new DataTable();
            foreach (DataRow row in myData.Rows)
            {
                Digimon d = new Digimon();
                d.Code = (int)row.Field<long>("id");
                if (row.IsNull("korean_name")) { d.KorName = ""; } else { d.KorName = (String?)row.Field<string>("korean_name"); }
                if (row.IsNull("dub_name")) { d.EngName = ""; } else { d.EngName = (String?)row.Field<Object>("dub_name"); }
                /*if (row.IsNull("icon_name") || !File.Exists(Path.GetFullPath("wwwroot") + "/images/DigimonIcons/" + (String?)row.Field<Object>("icon_name") + ".png")) { 
                    d.IconLink = "/images/Kuramon.png"; 
                } else { 
                    d.IconLink = "/images/DigimonIcons/" + (String?)row.Field<Object>("icon_name") + ".png";
                }
                if (row.IsNull("model_name") || !File.Exists(Path.GetFullPath("wwwroot") + "/images/DigimonModels/" + (String?)row.Field<Object>("model_name") + ".png")) { 
                    d.ModelLink = "/images/Tsumemon_404_Not_Found.png";
                } else { 
                    d.ModelLink = "/images/DigimonModels/" + (String?)row.Field<Object>("model_name") + ".png"; 
                }*/                
                if (row.IsNull("icon_link")) { 
                    
                } else { 
                    d.IconLink = (String?)row.Field<Object>("icon_link");
                }
                if (row.IsNull("model_link")) { 
                    
                } else { 
                    d.ModelLink = (String?)row.Field<Object>("model_link"); 
                }
                if (row.IsNull("evolution_tree")) { d.DigimonLine = ""; } else { d.DigimonLine = (String?)row.Field<Object>("evolution_tree"); }
                /*
                if (row.IsNull("stage")) { d.StageIcon = ""; } else { d.StageIcon = "/images/Stages/" + (String?)row.Field<Object>("stage") + ".png"; }
                if (row.IsNull("digimon_rank")) { d.Rank = "None"; } else { d.Rank = (String?)row.Field<Object>("digimon_rank"); }
                if (row.IsNull("rank_icon") || ((String?)row.Field<Object>("digimon_rank")).Equals("None")) { d.RankIcon = ""; } else { d.RankIcon = "/images/Ranks/" + (String?)row.Field<Object>("digimon_rank") + ".png"; }
                if (row.IsNull("attribute_icon")) { d.AttributeIcon = ""; } else { d.AttributeIcon = "/images/Attributes/" + (String?)row.Field<Object>("attribute_icon") + ".png"; }
                if (row.IsNull("element_icon")) { d.ElementIcon = ""; } else { d.ElementIcon = "/images/Elements/" + (String?)row.Field<Object>("element_icon") + ".png"; }
                if (row.IsNull("attacker_icon")) { d.AttackerIcon = ""; } else { d.AttackerIcon = "/images/Attackers/" + (String?)row.Field<Object>("attacker_icon") + ".png"; }
                if (row.IsNull("first_family")) { d.Family1 = ""; } else {d.Family1 = "/images/Families/" + (String?)row.Field<Object>("first_f_icon") + ".png";}
                if (row.IsNull("second_family")) { d.Family2 = ""; } else {d.Family2 = "/images/Families/" + (String?)row.Field<Object>("second_f_icon") + ".png";}
                if (row.IsNull("third_family")) { d.Family3 = ""; } else {d.Family3 = "/images/Families/" + (String?)row.Field<Object>("third_f_icon") + ".png";}
                if (row.IsNull("fourth_family")) { d.Family4 = ""; } else {d.Family4 = "/images/Families/" + (String?)row.Field<Object>("fourth_f_icon") + ".png";}
                */
                if (row.IsNull("stage_link")) { d.StageIcon = ""; } 
                else { d.StageIcon = (String?)row.Field<Object>("stage_link"); }
                if (row.IsNull("digimon_rank")) { d.Rank = "None"; } 
                else { d.Rank = (String?)row.Field<Object>("digimon_rank"); }
                if (row.IsNull("rank_link") || ((String?)row.Field<Object>("digimon_rank")).Equals("None")) { d.RankIcon = ""; } 
                else { d.RankIcon = (String?)row.Field<Object>("rank_link"); }
                if (row.IsNull("attribute_link")) { d.AttributeIcon = ""; } 
                else { d.AttributeIcon = (String?)row.Field<Object>("attribute_link"); }
                if (row.IsNull("element_link")) { d.ElementIcon = ""; } 
                else { d.ElementIcon = (String?)row.Field<Object>("element_link"); }
                if (row.IsNull("attacker_link")) { d.AttackerIcon = ""; } 
                else { d.AttackerIcon = (String?)row.Field<Object>("attacker_link"); }
                if (row.IsNull("first_f_link")) { d.Family1 = ""; } 
                else {d.Family1 = (String?)row.Field<Object>("first_f_link");}
                if (row.IsNull("second_f_link")) { d.Family2 = ""; } 
                else {d.Family2 = (String?)row.Field<Object>("second_f_link");}
                if (row.IsNull("third_f_link")) { d.Family3 = ""; } 
                else {d.Family3 = (String?)row.Field<Object>("third_f_link");}
                if (row.IsNull("fourth_f_link")) { d.Family4 = ""; } 
                else {d.Family4 = (String?)row.Field<Object>("fourth_f_link");}
                d.LvRequired = (String?)row.Field<Object>("level");
                d.DigimonStat = new DigimonStatService().getDigiStat(d.Code);
                d.DigimonSkills = new DigimonSkillService().searchDigimonSkills(d.Code);
                d.UnlockedItems = new ItemService().getItembyDigimon(d.Code, "unlock");
                d.EvolveItems = new ItemService().getItembyDigimon(d.Code, "evolve");
                d.RideItems = new ItemService().getItembyDigimon(d.Code, "ride");
                d.DRequired = new DRequirementService().getDigimonRequired(d.EngName);
                ddb.Add(d);
            }
            //ddb.Sort((x, y) => (x.EngName ?? "").CompareTo(y.EngName));
            return ddb;
        }

        public List<Digimon> SearchDigimonByDays(string text)
        {
            if (dataSQL == null)
            {
                dataSQL = new DBConnection();
            }
            ddb.Clear();
            string query = "select * from digimon_view where created_at >= date('now', '-90 days') order by created_at desc";
            dataSQL.pullSQL(query);
            DataTable myData = dataSQL.dataTable ?? new DataTable();
            foreach (DataRow row in myData.Rows)
            {
                Digimon d = new Digimon();
                d.Code = (int)row.Field<long>("id");
                if (row.IsNull("korean_name")) { d.KorName = ""; } else { d.KorName = (String?)row.Field<string>("korean_name"); }
                if (row.IsNull("dub_name")) { d.EngName = ""; } else { d.EngName = (String?)row.Field<Object>("dub_name"); }
                /*if (row.IsNull("icon_name") || !File.Exists(Path.GetFullPath("wwwroot") + "/images/DigimonIcons/" + (String?)row.Field<Object>("icon_name") + ".png")) { 
                    d.IconLink = "/images/Kuramon.png"; 
                } else { 
                    d.IconLink = "/images/DigimonIcons/" + (String?)row.Field<Object>("icon_name") + ".png";
                }
                if (row.IsNull("model_name") || !File.Exists(Path.GetFullPath("wwwroot") + "/images/DigimonModels/" + (String?)row.Field<Object>("model_name") + ".png")) { 
                    d.ModelLink = "/images/Tsumemon_404_Not_Found.png";
                } else { 
                    d.ModelLink = "/images/DigimonModels/" + (String?)row.Field<Object>("model_name") + ".png"; 
                }*/                
                if (row.IsNull("icon_link")) { 
                    
                } else { 
                    d.IconLink = (String?)row.Field<Object>("icon_link");
                }
                if (row.IsNull("model_link")) { 
                    
                } else { 
                    d.ModelLink = (String?)row.Field<Object>("model_link"); 
                }
                if (row.IsNull("evolution_tree")) { d.DigimonLine = ""; } else { d.DigimonLine = (String?)row.Field<Object>("evolution_tree"); }
                /*
                if (row.IsNull("stage")) { d.StageIcon = ""; } else { d.StageIcon = "/images/Stages/" + (String?)row.Field<Object>("stage") + ".png"; }
                if (row.IsNull("digimon_rank")) { d.Rank = "None"; } else { d.Rank = (String?)row.Field<Object>("digimon_rank"); }
                if (row.IsNull("rank_icon") || ((String?)row.Field<Object>("digimon_rank")).Equals("None")) { d.RankIcon = ""; } else { d.RankIcon = "/images/Ranks/" + (String?)row.Field<Object>("digimon_rank") + ".png"; }
                if (row.IsNull("attribute_icon")) { d.AttributeIcon = ""; } else { d.AttributeIcon = "/images/Attributes/" + (String?)row.Field<Object>("attribute_icon") + ".png"; }
                if (row.IsNull("element_icon")) { d.ElementIcon = ""; } else { d.ElementIcon = "/images/Elements/" + (String?)row.Field<Object>("element_icon") + ".png"; }
                if (row.IsNull("attacker_icon")) { d.AttackerIcon = ""; } else { d.AttackerIcon = "/images/Attackers/" + (String?)row.Field<Object>("attacker_icon") + ".png"; }
                if (row.IsNull("first_family")) { d.Family1 = ""; } else {d.Family1 = "/images/Families/" + (String?)row.Field<Object>("first_f_icon") + ".png";}
                if (row.IsNull("second_family")) { d.Family2 = ""; } else {d.Family2 = "/images/Families/" + (String?)row.Field<Object>("second_f_icon") + ".png";}
                if (row.IsNull("third_family")) { d.Family3 = ""; } else {d.Family3 = "/images/Families/" + (String?)row.Field<Object>("third_f_icon") + ".png";}
                if (row.IsNull("fourth_family")) { d.Family4 = ""; } else {d.Family4 = "/images/Families/" + (String?)row.Field<Object>("fourth_f_icon") + ".png";}
                */
                if (row.IsNull("stage_link")) { d.StageIcon = ""; } 
                else { d.StageIcon = (String?)row.Field<Object>("stage_link"); }
                if (row.IsNull("digimon_rank")) { d.Rank = "None"; } 
                else { d.Rank = (String?)row.Field<Object>("digimon_rank"); }
                if (row.IsNull("rank_link") || ((String?)row.Field<Object>("digimon_rank")).Equals("None")) { d.RankIcon = ""; } 
                else { d.RankIcon = (String?)row.Field<Object>("rank_link"); }
                if (row.IsNull("attribute_link")) { d.AttributeIcon = ""; } 
                else { d.AttributeIcon = (String?)row.Field<Object>("attribute_link"); }
                if (row.IsNull("element_link")) { d.ElementIcon = ""; } 
                else { d.ElementIcon = (String?)row.Field<Object>("element_link"); }
                if (row.IsNull("attacker_link")) { d.AttackerIcon = ""; } 
                else { d.AttackerIcon = (String?)row.Field<Object>("attacker_link"); }
                if (row.IsNull("first_f_link")) { d.Family1 = ""; } 
                else {d.Family1 = (String?)row.Field<Object>("first_f_link");}
                if (row.IsNull("second_f_link")) { d.Family2 = ""; } 
                else {d.Family2 = (String?)row.Field<Object>("second_f_link");}
                if (row.IsNull("third_f_link")) { d.Family3 = ""; } 
                else {d.Family3 = (String?)row.Field<Object>("third_f_link");}
                if (row.IsNull("fourth_f_link")) { d.Family4 = ""; } 
                else {d.Family4 = (String?)row.Field<Object>("fourth_f_link");}
                d.LvRequired = (String?)row.Field<Object>("level");
                d.DigimonStat = new DigimonStatService().getDigiStat(d.Code);
                d.DigimonSkills = new DigimonSkillService().searchDigimonSkills(d.Code);
                d.UnlockedItems = new ItemService().getItembyDigimon(d.Code, "unlock");
                d.EvolveItems = new ItemService().getItembyDigimon(d.Code, "evolve");
                d.RideItems = new ItemService().getItembyDigimon(d.Code, "ride");
                d.DRequired = new DRequirementService().getDigimonRequired(d.EngName);
                ddb.Add(d);
            }
            //ddb.Sort((x, y) => (x.EngName ?? "").CompareTo(y.EngName));
            return ddb;
        }

        public Digimon getDigimon(string evolutionTree, string digimon)
        {
            if (dataSQL == null)
            {
                dataSQL = new DBConnection();
            }
            Digimon d = new Digimon();
            string query = "SELECT * from digimon_view where dub_name='" + digimon + "' and evolution_tree ='" + evolutionTree + "'";
            dataSQL.pullSQL(query);
            DataTable myData = dataSQL.dataTable ?? new DataTable();
            if (myData.Rows.Count == 1)
            {
                DataRow row = myData.Rows[0];
                d.Code = (int)row.Field<long>("id");
                if (row.IsNull("korean_name")) { d.KorName = ""; } else { d.KorName = (String?)row.Field<string>("korean_name"); }
                if (row.IsNull("dub_name")) { d.EngName = ""; } else { d.EngName = (String?)row.Field<Object>("dub_name"); }
                /*if (row.IsNull("icon_name") || !File.Exists(Path.GetFullPath("wwwroot") + "/images/DigimonIcons/" + (String?)row.Field<Object>("icon_name") + ".png")) { 
                    d.IconLink = "/images/Kuramon.png"; 
                } else { 
                    d.IconLink = "/images/DigimonIcons/" + (String?)row.Field<Object>("icon_name") + ".png";
                }
                if (row.IsNull("model_name") || !File.Exists(Path.GetFullPath("wwwroot") + "/images/DigimonModels/" + (String?)row.Field<Object>("model_name") + ".png")) { 
                    d.ModelLink = "/images/Tsumemon_404_Not_Found.png";
                } else { 
                    d.ModelLink = "/images/DigimonModels/" + (String?)row.Field<Object>("model_name") + ".png"; 
                }*/                
                if (row.IsNull("icon_link")) { 
                    
                } else { 
                    d.IconLink = (String?)row.Field<Object>("icon_link");
                }
                if (row.IsNull("model_link")) { 
                    
                } else { 
                    d.ModelLink = (String?)row.Field<Object>("model_link"); 
                }
                if (row.IsNull("evolution_tree")) { d.DigimonLine = ""; } else { d.DigimonLine = (String?)row.Field<Object>("evolution_tree"); }
                /*
                if (row.IsNull("stage")) { d.StageIcon = ""; } else { d.StageIcon = "/images/Stages/" + (String?)row.Field<Object>("stage") + ".png"; }
                if (row.IsNull("digimon_rank")) { d.Rank = "None"; } else { d.Rank = (String?)row.Field<Object>("digimon_rank"); }
                if (row.IsNull("rank_icon") || ((String?)row.Field<Object>("digimon_rank")).Equals("None")) { d.RankIcon = ""; } else { d.RankIcon = "/images/Ranks/" + (String?)row.Field<Object>("digimon_rank") + ".png"; }
                if (row.IsNull("attribute_icon")) { d.AttributeIcon = ""; } else { d.AttributeIcon = "/images/Attributes/" + (String?)row.Field<Object>("attribute_icon") + ".png"; }
                if (row.IsNull("element_icon")) { d.ElementIcon = ""; } else { d.ElementIcon = "/images/Elements/" + (String?)row.Field<Object>("element_icon") + ".png"; }
                if (row.IsNull("attacker_icon")) { d.AttackerIcon = ""; } else { d.AttackerIcon = "/images/Attackers/" + (String?)row.Field<Object>("attacker_icon") + ".png"; }
                if (row.IsNull("first_family")) { d.Family1 = ""; } else {d.Family1 = "/images/Families/" + (String?)row.Field<Object>("first_f_icon") + ".png";}
                if (row.IsNull("second_family")) { d.Family2 = ""; } else {d.Family2 = "/images/Families/" + (String?)row.Field<Object>("second_f_icon") + ".png";}
                if (row.IsNull("third_family")) { d.Family3 = ""; } else {d.Family3 = "/images/Families/" + (String?)row.Field<Object>("third_f_icon") + ".png";}
                if (row.IsNull("fourth_family")) { d.Family4 = ""; } else {d.Family4 = "/images/Families/" + (String?)row.Field<Object>("fourth_f_icon") + ".png";}
                */
                if (row.IsNull("stage_link")) { d.StageIcon = ""; } 
                else { d.StageIcon = (String?)row.Field<Object>("stage_link"); }
                if (row.IsNull("digimon_rank")) { d.Rank = "None"; } 
                else { d.Rank = (String?)row.Field<Object>("digimon_rank"); }
                if (row.IsNull("rank_link") || ((String?)row.Field<Object>("digimon_rank")).Equals("None")) { d.RankIcon = ""; } 
                else { d.RankIcon = (String?)row.Field<Object>("rank_link"); }
                if (row.IsNull("attribute_link")) { d.AttributeIcon = ""; } 
                else { d.AttributeIcon = (String?)row.Field<Object>("attribute_link"); }
                if (row.IsNull("element_link")) { d.ElementIcon = ""; } 
                else { d.ElementIcon = (String?)row.Field<Object>("element_link"); }
                if (row.IsNull("attacker_link")) { d.AttackerIcon = ""; } 
                else { d.AttackerIcon = (String?)row.Field<Object>("attacker_link"); }
                if (row.IsNull("first_f_link")) { d.Family1 = ""; } 
                else {d.Family1 = (String?)row.Field<Object>("first_f_link");}
                if (row.IsNull("second_f_link")) { d.Family2 = ""; } 
                else {d.Family2 = (String?)row.Field<Object>("second_f_link");}
                if (row.IsNull("third_f_link")) { d.Family3 = ""; } 
                else {d.Family3 = (String?)row.Field<Object>("third_f_link");}
                if (row.IsNull("fourth_f_link")) { d.Family4 = ""; } 
                else {d.Family4 = (String?)row.Field<Object>("fourth_f_link");}
                d.LvRequired = (String?)row.Field<Object>("level");
                d.DigimonStat = new DigimonStatService().getDigiStat(d.Code);
                d.DigimonSkills = new DigimonSkillService().searchDigimonSkills(d.Code);
                d.UnlockedItems = new ItemService().getItembyDigimon(d.Code, "unlock");
                d.EvolveItems = new ItemService().getItembyDigimon(d.Code, "evolve");
                d.RideItems = new ItemService().getItembyDigimon(d.Code, "ride");
                d.DRequired = new DRequirementService().getDigimonRequired(d.EngName);
                return d;
            }
            else
            {
                return null;
            }
        }
    }
}