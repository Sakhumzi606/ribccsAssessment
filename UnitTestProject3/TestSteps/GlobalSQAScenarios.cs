using System;
using UnitTestProject3.TestManager;
using UnitTestProject3.Objects;
using System.Collections.Generic;
using System.IO;

namespace UnitTestProject3.TestSteps
{
    public class GlobalSQAScenarios : BaseClass
    {
        private XLS_Reader excelInputReader;
        string testURL;
        Random random = new Random();


        public GlobalSQAScenarios(string testURL)
        {
            SelDriver = new SeleniumDriverClass();
            SQAObjects = new ObjectClass();
            excelInputReader = new XLS_Reader();
            this.testURL = testURL;
        }

        public void RunTests(string testName)
        {
            this.EnsureNewBrowserInstance();

            if (testName.Equals("TrashDragAndDrop"))
            {
                if (dragAndDropImageInTrash())
                {
                    testResults = new TestResults("Drag and Drop in Trash", "Pass", "Navigate to Drag and Drop and move image to trash Randomly");
                }
                else
                {
                    testResults = new TestResults("Drag and Drop in Trash", "Fail", "Navigate to Drag and Drop and move image to trash Randomly");
                }
            }
            else if (testName.Equals("CountryDropDownMenu"))
            {
                if(navigateAndSelectCountry())
                {
                    testResults = new TestResults("DropDown Menu", "Pass", "Navigate to dropdown menu and select country randomly");
                }
                else
                {
                    testResults = new TestResults("DropDown Menu", "Fail", "Navigate to dropdown menu and select country randomly");
                }
            }
            else if (testName.Equals("FillSampleData"))
            {
                if(fillSamplePageTest())
                {
                    testResults = new TestResults("Fill Sample Page Test", "Pass", "Navigate to Sample Page Test and fill information");
                }
                else
                {
                    testResults = new TestResults("Fill Sample Page Test", "Fail", "Navigate to Sample Page Test and fill information");
                }
            }
            report = new TestReportGenerator(testResults);
            report.generateTestReport();
            SelDriver.ShutDown();
        }

        public bool dragAndDropImageInTrash()
        {
            if (!SelDriver.hoverOverMenuElementAndClickSubMenuByCss(GlobalSQAStepsHelper.dragAndDrop))
            { return false; }
            //validate Drag and drop page loaded successfully
            if (!SelDriver.waitForElementByCss(SQAObjects.dradAndDropPageHeaderCss()))
            { return false; }
            //validate photo manager tab is available
            SelDriver.waitForElementByCSSSelectorWithTimer(SQAObjects.photoManagerTabCss(), 100);
            //make sure photo manager tab is open
            SelDriver.ClickElementByCss(SQAObjects.photoManagerTabCss());
            //switch to iframe
            SelDriver.switchToFrameCss(SQAObjects.photoNanagerimagesIframeCss());
            //get number of images
            int imageCount = SelDriver.getElementsCountByCss(SQAObjects.numberOfImagesCss());

            if (imageCount > 0)
            {
                //drag image to trah by css
                SelDriver.dragAndDrop(SQAObjects.imageIndexCss(random.Next(1,imageCount)), SQAObjects.trashCss());
            }
            //switch back to main page
            SelDriver.switchToFrameDefault();

            return true;
        }

        public bool navigateAndSelectCountry()
        { 
            //navigate to dropdown menu
            if (!SelDriver.hoverOverMenuElementAndClickSubMenuByCss(GlobalSQAStepsHelper.dropDownMenu))
            { return false; }
            //validate DropDown Menu page loaded successfully
            if (!SelDriver.waitForElementByCss(SQAObjects.dradAndDropPageHeaderCss()))
            {return false;}
            //open countrytab
            if(!SelDriver.ClickElementByCss(SQAObjects.countryTabCss()))
            {return false;}
            //select country
            var ram = random.Next(GlobalSQAStepsHelper.country.Count);
            if (!SelDriver.selectByTextFromDropDownListUsingCss(SQAObjects.countrDropDownListCss(), GlobalSQAStepsHelper.country[ram]))
            {return false;}

            return true;
        }

        public bool fillSamplePageTest()
        {
            //load data from excel file
            testDataList = LoadTestData();
            if (testDataList.Count > 0)
            {
                TestDataList Data = testDataList[0];

                if (!SelDriver.hoverOverMenuElementAndClickSubMenuByCss(GlobalSQAStepsHelper.sampleData))
                { return false; }
                //uploadImage
                if (!SelDriver.UploadImageByCSS(SQAObjects.uploadImage()))
                { return false; }
                //Enter name
                if (!SelDriver.enterTextByCss(SQAObjects.sampleNameCss(), Data.getData("Name")))
                { return false; }
                //tab to email
                if (!SelDriver.tabCss(SQAObjects.sampleNameCss()))
                { return false; }
                //enter email
                if (!SelDriver.enterTextByCss(SQAObjects.sampleEmailCss(), Data.getData("Email")))
                { return false; }
                //enter website
                if (!SelDriver.enterTextByCss(SQAObjects.sampleWebsiteCss(), Data.getData("Website")))
                { return false; }
                //select years experience
                var ram = random.Next(GlobalSQAStepsHelper.experience.Count);
                if (!SelDriver.selectByTextFromDropDownListUsingCss(SQAObjects.sampleExperienceCss(), GlobalSQAStepsHelper.experience[ram]))
                { return false; }
                //randomly select expectise
                ram = random.Next(GlobalSQAStepsHelper.Expertise.Count);
                switch (GlobalSQAStepsHelper.Expertise[ram])
                {
                    case "Functional Testing":
                        SelDriver.ClickElementByCss(SQAObjects.sampleFunctionalTestingCss());
                        break;
                    case "Automation Testing":
                        SelDriver.ClickElementByCss(SQAObjects.sampleAutomationTestingCss());
                        break;
                    case "Manual Testing":
                        SelDriver.ClickElementByCss(SQAObjects.sampleManualTestingCss());
                        break;
                }

                //randomly select education
                ram = random.Next(GlobalSQAStepsHelper.education.Count);
                switch (GlobalSQAStepsHelper.education[ram])
                {
                    case "Graduate":
                        SelDriver.ClickElementByCss(SQAObjects.sampleGraduateCss());
                        break;
                    case " Post Graduate":
                        SelDriver.ClickElementByCss(SQAObjects.samplePostGraduateCss());
                        break;
                    case "Other":
                        SelDriver.ClickElementByCss(SQAObjects.sampleOtherCss());
                        break;
                }

                //enter comment
                if (!SelDriver.enterTextByCss(SQAObjects.sampleCommentCss(), "Experinced QA Analyst"))
                { return false; }

                //click submit button
                if (!SelDriver.ClickElementByCss(SQAObjects.sampleSubmitButtonCss()))
                { return false; }
            }
            return true;
        }

        public void EnsureNewBrowserInstance()
        {
            if (SelDriver.isDriverRunning())
            {
                SelDriver.ShutDown();
            }

            SelDriver.startDriver(testURL);
        }

        private List<TestDataList> LoadTestData()
        {

            string filrir = GetExcelFilePath() + "SampleData.xlsx";
            return this.excelInputReader.getTestDataFromExcelFile(filrir);
        }
    }
}
