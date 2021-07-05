using System;
using System.Collections.Generic;
using System.IO;
using UnitTestProject3.Objects;


namespace UnitTestProject3.TestManager
{
    public class BaseClass
    {
        public static TestResults testResults;
        public static SeleniumDriverClass SelDriver;
        public static ObjectClass SQAObjects;
        public static TestReportGenerator report;
        public static string ExcelFilePath;
        public static List<TestDataList> testDataList;


        public string GetExcelFilePath()
        {
            string ExcelFileDir = Directory.GetCurrentDirectory();
            ExcelFilePath = ExcelFileDir.Replace("\\UnitTestProject3\\bin\\Debug", "\\TestData\\");


            return ExcelFilePath;
        }
    }
}
