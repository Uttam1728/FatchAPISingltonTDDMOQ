using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FatchAPISingltonTDDMOQ
{
    public class JsonData
    {
        public string atleast_one_measure { get; set; }
        public string immunization_measure { get; set; }
        public string period { get; set; }
        public string registry_measure { get; set; }
        public string reportable_lab_results_measure { get; set; }
        public string stage_1_hospitals_all_measures { get; set; }
        public string stage_2_hospitals_all_measures { get; set; }
        public string syndromic_surveillance_measure { get; set; }
        public string region { get; set; }
        public string region_code { get; set; }
    }
}
