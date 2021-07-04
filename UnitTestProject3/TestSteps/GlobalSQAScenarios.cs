using System;
using UnitTestProject3.TestManager;
using UnitTestProject3.Objects;

namespace UnitTestProject3.TestSteps
{
    public class GlobalSQAScenarios
    {
        SeleniumDriverClass SelDriver;
        ObjectClass SQAObjects;
        string testURL;
        Random random = new Random();


        public GlobalSQAScenarios(string testURL)
        {
            SelDriver = new SeleniumDriverClass();
            SQAObjects = new ObjectClass();
            this.testURL = testURL;
        }

        public void RunTests(string testName)
        {
            if (testName.Equals("TrashDragAndDrop"))
            {
                this.EnsureNewBrowserInstance();
                this.dragAndDropImageInTrash();
                this.navigateAndSelectCountry();
                this.fillSamplePageTest();
            }
        }

        public bool dragAndDropImageInTrash()
        {
            //validate Drag and drop page loaded successfully
            SelDriver.waitForElementByCss(SQAObjects.dradAndDropPageHeaderCss());
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

            //navigate to country dropdown
            if (!SelDriver.hoverOverMenuElementAndClickSubMenuByCss())
            {return false;}
            //validate DropDown Menu page loaded successfully
            if (!SelDriver.waitForElementByCss(SQAObjects.dradAndDropPageHeaderCss()))
            {return false;}
            //open select countrytab
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
            //uploadImage
            //if (!SelDriver.UploadImageByCSS(SQAObjects.uploadImage()))
            //{ return false; }
            //Enter name
            if (!SelDriver.enterTextByCss(SQAObjects.sampleNameCss(),"John"))
            { return false; }
            //tab to email
            if (!SelDriver.tabCss(SQAObjects.sampleEmailCss()))
            { return false; }
            //enter email
            if (!SelDriver.enterTextByCss(SQAObjects.sampleEmailCss(),"johnD@mail.com"))
            { return false; }
            //enter website
            if (!SelDriver.enterTextByCss(SQAObjects.sampleEmailCss(), "www.johnD.com"))
            { return false; }
            //select years experience
            var ram = random.Next(GlobalSQAStepsHelper.experience.Count);
            if (!SelDriver.selectByTextFromDropDownListUsingCss(SQAObjects.sampleEmailCss(), GlobalSQAStepsHelper.experience[ram]))
            { return false; }
            //randomly select expectise
            ram = random.Next(GlobalSQAStepsHelper.Expertise.Count);
            switch(GlobalSQAStepsHelper.Expertise[ram])
            {
                case"Functional Testing":
                    SelDriver.ClickElementByCss(SQAObjects.sampleFunctionalTestingCss());
                    break;
                case"Automation Testing":
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
    }
}
