using System;
using System.Collections.Generic;
using System.IO;
using OfficeOpenXml;


namespace UnitTestProject3.TestManager
{
    public class XLS_Reader: BaseClass
    {
        ExcelWorksheet _WorkSheet;
        ExcelWorkbook _Workbook;
        ExcelPackage _ExcelPackage;
        FileStream inputFileStream;

        public XLS_Reader()
        {
            testDataList = new List<TestDataList>();
        }
        public List<TestDataList> getTestDataFromExcelFile(String filePath)
        {
            _Workbook = getExcelWorkbook(filePath);
            readExcelWorkSheet(_Workbook);
            retrieveTestDataFromSheet();

            this.DisposePackageHandle();

            return testDataList;
        }

        public ExcelWorkbook getExcelWorkbook(String filePath)
        {
            try
            {
                _ExcelPackage = new ExcelPackage();
                inputFileStream = new FileStream(@filePath, FileMode.Open, FileAccess.ReadWrite);
                _ExcelPackage.Load(inputFileStream);

                inputFileStream.Flush();

                inputFileStream.Close();


                return _ExcelPackage.Workbook;
            }
            catch (Exception e)
            {
                Console.Error.WriteLine("Error opening input file - " + e.Message);
                return null;
            }
        }

        public void DisposePackageHandle()
        {
            try
            {
                //this.inputFileStream.Dispose();
                this._ExcelPackage.Dispose();
            }
            catch
            {

            }
        }

        private bool readExcelWorkSheet(ExcelWorkbook workbook)
        {
            try
            {
                _WorkSheet = workbook.Worksheets[1];
                return true;
            }
            catch (Exception e)
            {
                Console.Error.WriteLine("Error reading first worksheet - " + e.Message);
                return false;
            }
        }

        private bool retrieveTestDataFromSheet()
        {
            if (_WorkSheet == null)
            {
                Console.Error.WriteLine("Worksheet is null");
                return false;
            }
            try
            {
                for (int rowNum = 1; rowNum <= _WorkSheet.Dimension.End.Row; rowNum++)
                {

                    String firstCellValue = _WorkSheet.Cells[rowNum, 1].Text;

                    if (!firstCellValue.Equals(String.Empty))
                    {
                        getTestParameters(rowNum, rowNum + 1);
                    }
                }
                return true;
            }
            catch (Exception e)
            {
                Console.Error.WriteLine("Error retrieve Test Data From Sheet worksheet - " + e.Message);
                return false;
            }
        }

        private String getCellValue(int rowNum, int columnIndex)
        {
            string cellValue = String.Empty;
            try
            {
                cellValue = this._WorkSheet.Cells[rowNum, columnIndex].Text ?? String.Empty;
            }
            catch (Exception e)
            {
                return "Value not processed correctly " + e.Message;
            }
            return cellValue;
        }

        private void getTestParameters(int parameterRowIndex, int valueRowIndex)
        {
            TestDataList testData = new TestDataList();
            int keyValuePairStartColumn = 1;

            for (int i = keyValuePairStartColumn; i <= _WorkSheet.Dimension.End.Column; i++)
            {
                String parameter = getCellValue(parameterRowIndex, i);

                String value = getCellValue(valueRowIndex, i);

                if (!parameter.Equals(String.Empty) && !value.Equals(String.Empty))
                {
                    testData.addParameter(parameter, value);
                }

            }
            if (testDataList == null)
            {
                testDataList = new List<TestDataList>();
            }
            testDataList.Add(testData);
        }
    }
}
