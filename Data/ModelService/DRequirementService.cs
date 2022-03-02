using System.Data;
using DigitalNetWeb.Data.Models;

namespace DigitalNetWeb.Data.ModelService
{
    public class DRequirementService
    {

        private DBConnection? dataSQL;

        public DRequirementService() { }

        public List<DRequired> getDigimonRequired(string dName)
        {
            if (dataSQL == null)
            {
                dataSQL = new DBConnection();
            }
            string query = "SELECT * FROM digimon_required";
            dataSQL.pullSQL(query);
            List<DRequired> required = new List<DRequired>();
            DataTable myData = dataSQL.dataTable ?? new DataTable();
            foreach (DataRow row in myData.Rows)
            {
                if (((String?)row.Field<Object>("dub_Name")).Equals(dName))
                {
                    DRequired d = new DRequired();
                    d.Code = (int)row.Field<long>("id");
                    d.EngName = (String?)row.Field<Object>("dub_Name");
                    d.Required = (String?)row.Field<Object>("required");
                    d.IconLink = "/images/DigimonIcons/" + d.Required + ".png";
                    DigimonLine dl = new DigimonLineService().getDigimonLine(d.Required, d.EngName);
                    if (dl != null)
                    {
                        Digimon di = new DigimonService().getDigimon(dl.EngName, d.Required);
                        if (di != null)
                        {
                            d.RequiredD = di;
                            d.IconLink = di.IconLink;
                        }
                    }

                    required.Add(d);
                }
            }
            return required;
        }
    }
}