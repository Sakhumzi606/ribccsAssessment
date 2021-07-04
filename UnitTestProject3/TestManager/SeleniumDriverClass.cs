using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Chrome;
using System.Threading;
using System.Collections.Generic;


namespace UnitTestProject3.TestManager
{
    public class SeleniumDriverClass
    {
        IWebDriver Driver = null;
        bool DriverRunning = false;

        public SeleniumDriverClass()
        {
        }

        public IWebDriver startDriver(string TestUrl)
        {
            Driver = new ChromeDriver();
           
            Driver.Manage().Window.Maximize();
            Driver.Navigate().GoToUrl(TestUrl); 
            DriverRunning = true;

            return Driver;

        }

        public bool isDriverRunning()
        {
            return DriverRunning;
        }

        public void ShutDown()
        {
            try
            {
                if (isDriverRunning())
                {
                    Driver.Close();
                }
            }
            catch(Exception)
            { }

            DriverRunning = false;
        }

        public bool ClickElementByCss(string elementCssSelector)
        {
            try
            {
                Thread.Sleep(1000);
                this.waitForElementByCss(elementCssSelector);
                Driver.FindElement(By.CssSelector(elementCssSelector)).Click();
                Console.WriteLine("[Info] Element clicked - " + elementCssSelector);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public int getElementsCountByCss(string elementCssSelector)
        {
            int number = 0;
            try
            {
                Thread.Sleep(1000);
                number = Driver.FindElements(By.CssSelector(elementCssSelector)).Count;
            }
            catch (Exception)
            {
            }

            return number;
        }

        public bool waitForElementByCss(string elementCssSelector)
        {
            bool elementFound = false;

            try
            {
                int waitCount = 0;
                while (!elementFound && waitCount < 200)
                {
                    try
                    {
                        Driver.FindElement(By.CssSelector(elementCssSelector));
                        elementFound = true;
                        break;
                    }
                    catch (Exception)
                    {
                        elementFound = false;
                    }
                    Thread.Sleep(500);
                    waitCount++;
                }
            }
            catch (Exception)
            {
                return false;
            }

            return elementFound;
        }

        public bool waitForElementByXpathWithTimer(string elementXpath, int timer)
        {
            bool elementFound = false;

            try
            {
                int waitCount = 0;
                while (!elementFound && waitCount < timer)
                {
                    try
                    {
                        Driver.FindElement(By.XPath(elementXpath));
                        elementFound = true;
                        break;
                    }
                    catch (Exception)
                    {
                        elementFound = false;
                    }
                    Thread.Sleep(500);
                    waitCount++;
                }
            }
            catch (Exception)
            {
                return false;
            }

            return elementFound;
        }

        public bool waitForElementByCSSSelectorWithTimer(string elementCssSelector,int timer)
        {
            bool elementFound = false;
            try
            {
                int waitCount = 0;
                while (!elementFound && waitCount < timer)
                {
                    try
                    {
                        Driver.FindElement(By.CssSelector(elementCssSelector));
                        elementFound = true;
                        break;
                    }
                    catch (Exception)
                    {
                        elementFound = false;
                    }
                    Thread.Sleep(500);
                    waitCount++;
                }
            }
            catch (Exception)
            {
                return false;
            }

            return elementFound;
        }

        public bool switchToFrameCss(string elementCss)
        {
           try
            {
                waitForElementByCss(elementCss);
                IWebElement fram = Driver.FindElement(By.CssSelector(elementCss));
                Driver.SwitchTo().Frame(fram);
            }
            catch (Exception)
            {
                return false;
            }
           return true;
        }

        public bool switchToFrameDefault()
        {
            try
            {
                Driver.SwitchTo().DefaultContent();

            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public bool dragAndDrop(string FromElementCss,string toElementCss)
        {
            try
            {
                waitForElementByCss(FromElementCss);
                IWebElement From = Driver.FindElement(By.CssSelector(FromElementCss));
                IWebElement To = Driver.FindElement(By.CssSelector(toElementCss));

                Actions action = new Actions(Driver);

                action.DragAndDrop(From, To).Build().Perform();

            }
            catch(Exception)
            {
                return false;
            }


            return true;
        }

        public bool hoverOverMenuElementAndClickSubMenuByCss()
        {
            try
            {
                this.waitForElementByXpathWithTimer("//div[@id='menu']//li/a[contains(text(),\"Tester’s Hub\")]", 50);

                Actions action = new Actions(Driver);
                IWebElement menulevelhover = Driver.FindElement(By.XPath("//div[@id='menu']//li/a[contains(text(),\"Tester’s Hub\")]"));
                action.MoveToElement(menulevelhover);

                menulevelhover = Driver.FindElement(By.XPath("//li//span[contains(text(),'Demo Testing Site')]"));
                action.MoveToElement(menulevelhover);

                menulevelhover = Driver.FindElement(By.XPath("//li//span[contains(text(),'DropDown Menu')]"));
                action.MoveToElement(menulevelhover);

                Thread.Sleep(1000);

                action.Click();
                action.Perform();

            }
            catch(Exception)
            {
                return false;
            }

            return true;
        }

        public bool hoverOverMenuElementAndClickSubMenuByCss1(List<string> list)
        {
            try
            {
                this.waitForElementByXpathWithTimer("//div[@id='menu']//li/a[contains(text(),\"Tester’s Hub\")]", 50);

                Actions action = new Actions(Driver);
                IWebElement menulevelhover = Driver.FindElement(By.XPath("//div[@id='menu']//li/a[contains(text(),\"Tester’s Hub\")]"));
                action.MoveToElement(menulevelhover);

                menulevelhover = Driver.FindElement(By.XPath("//li//span[contains(text(),'Demo Testing Site')]"));
                action.MoveToElement(menulevelhover);

                menulevelhover = Driver.FindElement(By.XPath("//li//span[contains(text(),'DropDown Menu')]"));
                action.MoveToElement(menulevelhover);

                Thread.Sleep(1000);

                action.Click();
                action.Perform();

            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public bool selectByTextFromDropDownListUsingCss(string elementCss, string valueToSelect)
        {
            try
            {
                waitForElementByCss(elementCss);
                SelectElement dropDownList = new SelectElement(Driver.FindElement(By.CssSelector(elementCss)));
                dropDownList.SelectByText(valueToSelect);
            }
            catch (Exception )
            {
                return false;
            }
            return true;
        }

        public bool UploadImageByCSS(string elementCss)
        {
            try
            {
                String script = "document.querySelector('" + elementCss + "').value='" + @"C:\\\Documents\\PlayingAround\\ribccsAssessment\\UnitTestProject3\\Image\\user.png" + "';";
                ((IJavaScriptExecutor)Driver).ExecuteScript(script);
            }
            catch (Exception)
            {
            }

            return true;
        }

        public bool enterTextByCss(string elementCss, string textToEnter)
        {
            try
            {
                Thread.Sleep(500);
                waitForElementByCss(elementCss);
                Driver.FindElement(By.CssSelector(elementCss)).Clear();
                Driver.FindElement(By.CssSelector(elementCss)).SendKeys(textToEnter);
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public bool tabCss(string elementCss)
        {
            try
            {
                Thread.Sleep(500);
                waitForElementByCss(elementCss);
                Driver.FindElement(By.Id(elementCss)).SendKeys(Keys.Tab);
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

    }
}
