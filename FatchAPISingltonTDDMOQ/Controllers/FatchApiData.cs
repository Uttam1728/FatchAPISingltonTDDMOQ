using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace FatchAPISingltonTDDMOQ.Controllers
{
    [Route("api/[controller]")]
    public class FatchApiData : Controller
    {
        public List<JsonData> WholeData { get; private set; }

        public FatchApiData()
        {

            var json = new WebClient().DownloadString("https://dashboard.healthit.gov/api/open-api.php?source=hospital-mu-public-health-measures.csv");
            this.WholeData = JsonSerializer.Deserialize<List<JsonData>>(json);

        }

        [Route("getstatelist")]
        [HttpGet]
        public HashSet<string> GetStateList()
        {
            HashSet<string> s = new HashSet<string>(); ;
            foreach (JsonData ele in WholeData)
            {
                s.Add(ele.region);
            }
            return s;
        }

        [Route("getstatedata")]
        [HttpGet]
        public JsonData GetStatedata(string year, string state)
        {
            return year == null || state == null ? null : WholeData.Where(x => x.period == year && x.region == state).FirstOrDefault();
        }
    }
}
