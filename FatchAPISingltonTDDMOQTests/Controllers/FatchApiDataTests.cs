using Microsoft.VisualStudio.TestTools.UnitTesting;
using FatchAPISingltonTDDMOQ.Controllers;
using System;
using System.Collections.Generic;
using System.Text;
using Moq;
using FatchAPISingltonTDDMOQ.SingleTonFatchDataRepo;
using FatchAPISingltonTDDMOQ.Models;

namespace FatchAPISingltonTDDMOQ.Controllers.Tests
{
    [TestClass()]
    public class FatchApiDataTests
    {
        [TestMethod()]
        public void GetStatedataTest()
        {
            //create
            var mock = new Mock<ISingleTonFatchData>();

            //setup
            var year = "2015";
            var state = "Alaska";
            JsonData statedata = new JsonData() { region = "Alaska", region_code = "AK", period = "2014", atleast_one_measure = "0.89", immunization_measure = "0.92", reportable_lab_results_measure = "0.31", syndromic_surveillance_measure = "0.31", registry_measure = "", stage_2_hospitals_all_measures = "1", stage_1_hospitals_all_measures = "0" };
            mock.Setup(x => x.GetStateData(year, state)).Returns(statedata);
            var FatchApiDataCtrler = new FatchApiData(mock.Object);

            //verify
            var result = FatchApiDataCtrler.GetStatedata(year,state);
            Assert.AreEqual(statedata, result);
//
        }
    }
}