using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FatchAPISingltonTDDMOQ.SingleTonFatchDataRepo
{
    public interface ISingleTonFatchData
    {

        HashSet<string> GetStateList();

        JsonData GetStateData(string year, string state);
    }
}
