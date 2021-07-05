using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject3.TestManager
{
    public class TestResults
    {
        string testName;
        string testResult;
        string testDescription;

        public TestResults(string testName,string testResult,string testDescription)
        {
            this.testName = testName; this.testResult = testResult;
            this.testDescription = testDescription;
        }
        public string TestName
        {
            get { return testName; }
            set { testName = value; }
        }
        public string TestResult
        {
            get { return testResult; }
            set { testResult = value; }
        }
        public string TestDescription
        {
            get { return testDescription; }
            set { testDescription = value; }
        }
    }
}
