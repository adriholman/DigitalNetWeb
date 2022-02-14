using System.Data;
using DigitalNetWeb.Data.Models;

namespace DigitalNetWeb.Data.ModelService
{
    public class TamerService
    {
        private List<Tamer> ddb = new List<Tamer>();
        private DBConnection? dataSQL;
        public TamerService() { }

        public List<Tamer> searchForTamer(String text)
        {
            if (dataSQL == null)
            {
                dataSQL = new DBConnection();
            }
            ddb.Clear();
            String query = "SELECT * FROM tamers_list where searchText like '%" + text + "%' or korean_name like '%" + text + "%' or active_skill like '" + text + "' or first_passive like '" + text + "' or second_passive like '" + text + "' or first_attribute like '" + text + "' or second_attribute like '" + text + "'";
            dataSQL.pullSQL(query);
            DataTable myData = dataSQL.dataTable ?? new DataTable(); ;
            foreach (DataRow row in myData.Rows)
            {
                Tamer ds = new Tamer();
                ds.Code = (int)row.Field<long>("id");
                ds.Nickname = (String?)row.Field<object>("nick_name");
                ds.EngName = (String?)row.Field<object>("dub_name");
                ds.KorName = (String?)row.Field<object>("korean_name");
                if (row.IsNull("icon_link")) { ds.IconLink = "https://i.imgur.com/dEBKEO7.png"; } else { ds.IconLink = (String?)row.Field<Object>("icon_link"); }
                if (row.IsNull("model_link")) { ds.ModelLink = ""; } else { ds.ModelLink = (String?)row.Field<Object>("model_link"); }
                ds.ASkillName = (String?)row.Field<object>("active_skill");
                ds.ASkillD = (String?)row.Field<object>("active_skill_desc");
                ds.ASkillCD = (String?)row.Field<object>("active_skill_cd");
                ds.PSkill1N = (String?)row.Field<object>("first_passive");
                ds.PSkill1B = (String?)row.Field<object>("first_bonus");
                ds.PSkill1A = (String?)row.Field<object>("first_attribute");
                ds.PSkill2N = (String?)row.Field<object>("second_passive");
                ds.PSkill2B = (String?)row.Field<object>("second_bonus");
                ds.PSkill2A = (String?)row.Field<object>("second_attribute");
                ds.AT = (int)row.Field<long>("at");
                ds.DE = (int)row.Field<long>("de");
                ds.HP = (int)row.Field<long>("hp");
                ds.DS = (int)row.Field<long>("ds");
                ddb.Add(ds);
            }
            return ddb;
        }
    }
}