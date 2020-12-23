using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using FatchAPISingltonTDDMOQ.SingleTonFatchDataRepo;
using FatchAPISingltonTDDMOQ.Models;

namespace FatchAPISingltonTDDMOQ.Controllers
{
    [Route("api/[controller]")]
    public class FatchApiData : Controller
    {
        private ISingleTonFatchData _ds;

        public FatchApiData(ISingleTonFatchData ds)
        {
            _ds = ds;
            
        }

        
        [HttpGet("getstatelist")]
        public HashSet<string> GetStateList()
        {
            return _ds.GetStateList();
        }

       
        [HttpGet("getstatedata/{year}/{state}")]
        public JsonData GetStatedata(string year, string state)
        {
            var data =  _ds.GetStateData(year, state);
            return data;
        }
    }
}
