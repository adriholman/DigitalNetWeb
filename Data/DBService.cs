using System.Data;
using DigitalNetWeb.Data;
using DigitalNetWeb.Data.Models;
using DigitalNetWeb.Data.ModelService;

namespace DigitalNetWeb.Data
{
    public class DBService{

        public DBService(){}
        public Task<DBObject[]> SearchObjects(string text)
        {
            List<DBObject> mySearch = new List<DBObject>();
            mySearch.AddRange(new DigimonService().SearchDigimon(text));
            mySearch.AddRange(new ItemService().SearchForItems(text));

            mySearch.Sort((x, y) => (x.EngName ?? "").CompareTo(y.EngName));
            return Task.FromResult(mySearch.ToArray());
        }
    }
}