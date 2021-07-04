using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject3.TestSteps
{
    internal class GlobalSQAStepsHelper
    {
        internal static readonly List<string> country = new List<string>
        {
                "Afghanistan",
                "Åland Islands",
                "Algeria",
                "Albania",
                "Andorra",
                "American Samoa",
                "Austria",
                "Bangladesh",
                "Belgium",
        };

        internal static readonly List<string> education = new List<string>
        {
               "Graduate",
               "Post Graduate",
               "Other",
        };
        internal static readonly List<string> Expertise = new List<string>
        {
               "Functional Testing",
               "Automation Testing",
               "Manual Testing",
        };
        internal static readonly List<string> experience = new List<string>
        {
               "0-1",
               "1-3",
               "3-5",
               "5-7",
               "7-10",
               "10+",
        };
    }
}
