using System;
using System.IO;
using System.Text;

namespace UnitTestProject3.TestManager
{
    public class TestReportGenerator:BaseClass
    {
        StringBuilder HtmlReportBuilder;

        public TestReportGenerator(TestResults results)
        {
            testResults = results;
            HtmlReportBuilder = new StringBuilder();
        }

        public void generateTestReport()
        {
            HtmlReportBuilder.Append("<!doctype html>\n");
            HtmlReportBuilder.Append("<html lang='en'>\n");

            HtmlReportBuilder.Append("<head>\n");
            HtmlReportBuilder.Append("<meta charset='utf-8'>\n");
            HtmlReportBuilder.Append("<title style=\"font-family:verdana;\">Automation Report</title>\n");
            HtmlReportBuilder.Append("<style>");
            HtmlReportBuilder.Append("h1 { width: 10%; font-size: 40px;word-wrap: break-word;letter-spacing: 20px;}");
            HtmlReportBuilder.Append("</style>");
            HtmlReportBuilder.Append("</head>\n\n");
            HtmlReportBuilder.Append("<body>\n");
            HtmlReportBuilder.Append("<table cellpadding=\"2\" cellspacing=\"0\" width=\"100%\" style=\" border-collapse:collapse; font-family:verdana; border:1px solid black\">\n");
            HtmlReportBuilder.Append("<tr style=\"outline: thin solid black;\">\n");
            HtmlReportBuilder.Append("<th width=\"100%\" colspan=\"4\" align=\"center\" style=\"border-left:1px solid black;background-color:#A52A2A;color:#ffffff;\">Test Assessment Automation Report</th>\n");
            HtmlReportBuilder.Append("</tr>\n");
            HtmlReportBuilder.Append("<tr style=\"outline: thin solid black;\">\n");
            HtmlReportBuilder.Append("<th width=\"30%\" style=\"border-left:1px solid black;background-color:#A52A2A;color:#ffffff;\">Test Name</th>\n");
            HtmlReportBuilder.Append("<th width=\"30%\" style=\"border-left:1px solid black;background-color:#A52A2A;color:#ffffff;\">Test Description</th>\n");
            HtmlReportBuilder.Append("<th width=\"10%\" style=\"border-left:1px solid black;background-color:#A52A2A;color:#ffffff;\">Pass\\Fail</th>\n");
            HtmlReportBuilder.Append("</tr>\n");
            HtmlReportBuilder.Append("<tr style=\"outline: thin solid black;\">\n");
            HtmlReportBuilder.Append("<td style=\"border-left:1px solid black;\"> " + testResults.TestName + " </td>\n");
            HtmlReportBuilder.Append("<td style=\"border-left:1px solid black;\"> " + testResults.TestDescription + " </td>\n");
            if (testResults.TestResult.ToUpper().Equals("Pass".ToUpper()))
            { HtmlReportBuilder.Append("<td style=\"border-left:1px solid black;background-color:#00FF00;\"> " + testResults.TestResult + " </td>\n"); }
            else if (testResults.TestResult.ToUpper().Equals("Fail".ToUpper()))
            { HtmlReportBuilder.Append("<td style=\"border-left:1px solid black;background-color:#ff0000;\"> " + testResults.TestResult + " </td>\n"); }

            HtmlReportBuilder.Append("</tr>\n");
            HtmlReportBuilder.Append("</table>\n");
            HtmlReportBuilder.Append("</body>\n\n");
            HtmlReportBuilder.Append("</html>\n");

            String date = DateTime.Now.ToString("(yyyy-MM-dd)(HH-mm-ss)");
            this.GenerateReport(date + "TestReport.html");
        }
        public void GenerateReport(String htmlReportFileName)
        {
            string path = "";
            try
            {
                path = Directory.GetCurrentDirectory();
                path = path.Replace("\\UnitTestProject3\\bin\\Debug", "\\AutomationResults");
                Directory.CreateDirectory(path);
                File.WriteAllText(path + "\\" + htmlReportFileName, HtmlReportBuilder.ToString());
            }
            catch (Exception e)
            {
                Console.WriteLine("Failed to generate report  - Fault - " + e.Message);
            }
        }
    }
}
