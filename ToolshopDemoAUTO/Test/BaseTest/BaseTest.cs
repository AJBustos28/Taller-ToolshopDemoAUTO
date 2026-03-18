using AventStack.ExtentReports;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using ToolshopDemoAUTO.Genericos.DriverConfig;
using AventStack.ExtentReports.Reporter;

namespace ToolshopDemoAUTO.Test.BaseTest
{
    public abstract class BaseTest
    {
        
        protected IWebDriver Driver;
        public BaseTest() { }

        [SetUp]
        public void Setup()
        {
            var options = new ChromeOptions();
            options.AddArgument("--start-maximized");

            Driver = ChromeFactory.CreateDriver(options);
        }
        [TearDown]
        public void TearDown()
        {
            try
            {
                Driver.Dispose();
            }
            catch (Exception ex01)
            {

            }
        }
    }
}
