using FatchAPISingltonTDDMOQ.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace FatchAPISingltonTDDMOQ.SingleTonFatchDataRepo
{
    public class SingleTonFatchData : ISingleTonFatchData
    {
        public SingleTonFatchData()
        {
            var json = new WebClient().DownloadString("https://dashboard.healthit.gov/api/open-api.php?source=hospital-mu-public-health-measures.csv");
            this.WholeData = JsonSerializer.Deserialize<List<JsonData>>(json);
        }

        public List<JsonData> WholeData { get; private set; }

        public JsonData GetStateData(string year, string state)
        {
            return year == null || state == null ? null : WholeData.Where(x => x.period == year && x.region == state).FirstOrDefault();
        }

        public HashSet<string> GetStateList()
        {
            HashSet<string> s = new HashSet<string>(); ;
            foreach (JsonData ele in WholeData)
            {
                s.Add(ele.region);
            }
            return s;
        }
    }
}
