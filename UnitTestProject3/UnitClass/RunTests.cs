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
            scenarios = new GlobalSQAScenarios("https://www.globalsqa.com/demo-site/draganddrop/");
            scenarios.RunTests("TrashDragAndDrop");
        }
    }
}
