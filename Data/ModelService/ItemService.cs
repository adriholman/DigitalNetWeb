using System.Data;
using DigitalNetWeb.Data.Models;

namespace DigitalNetWeb.Data.ModelService
{
    public class ItemService
    {
        private DBConnection? dataSQL;
        public ItemService() { }

        public List<Item> SearchForItems(String text)
        {
            if (dataSQL == null)
            {
                dataSQL = new DBConnection();
            }
            List<Item> s = new List<Item>();
            String query = "select * from items_view where (name like '%" + text + "%' or korean_name like '%" + text + "%' or description like '%" + text + "%')";
            dataSQL.pullSQL(query);
            DataTable myData = dataSQL.dataTable ?? new DataTable();
            foreach (DataRow row in myData.Rows)
            {
                Item i = new Item();
                i.Code = (int)row.Field<long>("id");
                if (row.IsNull("korean_name")) { i.KorName = ""; } else { i.KorName = (String?)row.Field<String>("korean_name"); }
                if (row.IsNull("name")) { i.EngName = ""; } else { i.EngName = (String?)row.Field<Object>("name"); }
                if (row.IsNull("icon_name") || !File.Exists("/images/ItemIcons/" + (String?)row.Field<Object>("icon_name") + ".png")) { i.IconLink = "/images/Kuramon.gif"; } else { i.IconLink = "/images/ItemIcons/" + (String?)row.Field<Object>("icon_name") + ".png"; }
                if (row.IsNull("category")) { i.category = ""; } else { i.category = (String?)row.Field<Object>("category"); }
                if (row.IsNull("description")) { i.Description = ""; } else { i.Description = (String?)row.Field<Object>("description"); }
                s.Add(i);
            }
            //s.Sort((x, y) => x.EngName.CompareTo(y.EngName));
            return s;
        }
    }
}