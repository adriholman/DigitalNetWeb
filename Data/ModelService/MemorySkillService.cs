using System.Data;
using DigitalNetWeb.Data.Models;

namespace DigitalNetWeb.Data.ModelService
{
    public class MemorySkillService
    {
        private DBConnection? dataSQL;
        public MemorySkillService() { }

        public List<MemorySkillDataCube> searchForMemoryCube(String text)
        {
            if (dataSQL == null)
            {
                dataSQL = new DBConnection();
            }
            List<MemorySkillDataCube> s = new List<MemorySkillDataCube>();
            String query = "SELECT * FROM cube_memory_skills where dub_name like '%" + text + "%' or korean_name like '%" + text + "%' or type like '%" + text + "%'";
            dataSQL.pullSQL(query);
            DataTable myData = dataSQL.dataTable ?? new DataTable();
            foreach (DataRow row in myData.Rows)
            {
                MemorySkillDataCube ms = new MemorySkillDataCube();
                ms.Code = (int)row.Field<long>("id");
                ms.Type = (String?)row.Field<object>("type");
                ms.KorName = (String?)row.Field<object>("korean_name");
                ms.EngName = (String?)row.Field<object>("dub_name");
                if (row.IsNull("icon_link")) { ms.IconLink = "https://i.imgur.com/dEBKEO7.png"; } else { ms.IconLink = (String?)row.Field<Object>("icon_link"); }
                ms.Description = (String?)row.Field<object>("description");
                ms.Description_es = (String?)row.Field<object>("description_es");
                ms.Level_1 = (String?)row.Field<object>("lv_1");
                ms.Level_2 = (String?)row.Field<object>("lv_2");
                ms.Level_3 = (String?)row.Field<object>("lv_3");
                ms.Cd = (String?)row.Field<object>("cd");
                s.Add(ms);
            }
            return s;
        }

        public List<MemorySkillDataCapsule> searchForMemoryCapsule(String text)
        {
            if (dataSQL == null)
            {
                dataSQL = new DBConnection();
            }
            List<MemorySkillDataCapsule> s = new List<MemorySkillDataCapsule>();
            String query = "SELECT * FROM capsule_memory_skills where dub_name like '%" + text + "%'";
            dataSQL.pullSQL(query);
            DataTable myData = dataSQL.dataTable ?? new DataTable();
            foreach (DataRow row in myData.Rows)
            {
                MemorySkillDataCapsule ms = new MemorySkillDataCapsule();
                ms.Code = (int)row.Field<long>("id");
                ms.Type = (String?)row.Field<object>("type");
                ms.KorName = (String?)row.Field<object>("korean_name");
                ms.EngName = (String?)row.Field<object>("dub_name");
                if (row.IsNull("icon_link")) { ms.IconLink = "https://i.imgur.com/dEBKEO7.png"; } else { ms.IconLink = (String?)row.Field<Object>("icon_link"); }
                ms.Description = (String?)row.Field<object>("description");
                ms.Description_es = (String?)row.Field<object>("description_es");
                ms.Bonus_low = (String?)row.Field<object>("low");
                ms.Bonus_mid = (String?)row.Field<object>("mid");
                ms.Bonus_high = (String?)row.Field<object>("high");
                ms.Bonus_highest = (String?)row.Field<object>("highest");
                ms.Cd = (String?)row.Field<object>("cd");
                s.Add(ms);
            }
            return s;
        }
    }
}