using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTestProject3.TestSteps;

namespace UnitTestProject3
{
    [TestClass]
    public class RunTests
    {
        GlobalSQAScenarios scenarios;
 
        [TestMethod]
        public void runDragAndDrop()
        {
            scenarios = new GlobalSQAScenarios("https://www.globalsqa.com/");
            
            scenarios.RunTests("TrashDragAndDrop");
        }
        [TestMethod]
        public void runSelectCountry()
        {
            scenarios = new GlobalSQAScenarios("https://www.globalsqa.com/");

            scenarios.RunTests("CountryDropDownMenu");
        }
        [TestMethod]
        public void runFillSampleData()
        {
            scenarios = new GlobalSQAScenarios("https://www.globalsqa.com/");

            scenarios.RunTests("FillSampleData");
        }
        
    }
}
