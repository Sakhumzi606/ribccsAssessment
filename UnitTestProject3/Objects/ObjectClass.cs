using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject3.Objects
{
    public class ObjectClass
    {
        public string dradAndDropPageHeaderCss()
        {
            return "[class='page_heading']";
        }

        public string photoNanagerimagesIframeCss()
        {
            return "[class='demo-frame lazyloaded']";
        }

        public string photoManagerTabCss()
        {
            return "li[id='Photo Manager']";
        }

        public string numberOfImagesCss()
        {
            return "ul[id='gallery'] li";
        }

        public string imageIndexCss(int index)
        {
            return "ul[id='gallery'] li:nth-child(" + index + ")";
        }

        public string trashCss()
        {
            return "div[id='trash']";
        }

        public string countryTabCss()
        {
            return "li[id='Select Country']";
        }

        public string countrDropDownListCss()
        {
            return "div[rel-title='Select Country'] select";
        }

        public string uploadImage()
        {
            return "input[type='file']";
        }

        public string sampleNameCss()
        {
            return "input[class='name']";
        }

        public string sampleEmailCss()
        {
            return "input[class='email']";
        }

        public string sampleWebsiteCss()
        {
            return "input[name*='website']";
        }

        public string sampleExperienceCss()
        {
            return "select[name*='experienceinyears']";
        }

        public string sampleFunctionalTestingCss()
        {
            return "input[value='Functional Testing']";
        }

        public string sampleAutomationTestingCss()
        {
            return "input[value='Automation Testing']";
        }

        public string sampleManualTestingCss()
        {
            return "input[value='Manual Testing']";
        }

        public string sampleGraduateCss()
        {
            return "input[value='Graduate']";
        }

        public string samplePostGraduateCss()
        {
            return "input[value='Post Graduate']";
        }

        public string sampleOtherCss()
        {
            return "input[value='Other']";
        }

        public string sampleCommentCss()
        {
            return "textarea[name*='comment']";
        }

        public string sampleSubmitButtonCss()
        {
           return "button[class*='pushbutton-wide']";
        }
    }
}
