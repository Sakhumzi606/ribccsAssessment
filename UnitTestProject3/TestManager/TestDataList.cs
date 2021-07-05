using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject3.TestManager
{
    public class TestDataList
    {
  
        public Dictionary<string, string> TestParameters;

        public TestDataList()
        {

        }

        public void addParameter(String parameterName, String parameterValue)
        {
            if (TestParameters == null)
            {
                this.TestParameters = new Dictionary<string, string>();
            }
            this.TestParameters.Add(parameterName, parameterValue);
        }

        public void updateParameterValue(String parameterName, String parameterValue)
        {
            if (TestParameters != null && TestParameters.ContainsKey(parameterName))
            {
                this.TestParameters.Add(parameterName, parameterValue);
            }
            else
            {
                Console.WriteLine("Error - Parameter name does not exist in the test data");
            }
        }

        public string getData(string parameterName)
        {
            try
            {
                string returnValue = this.TestParameters[parameterName];

                if (returnValue == null)
                    return "Parameter not found";
                else
                    return returnValue;
            }
            catch
            {
                return "Parameter not found";
            }

        }
    }
}
