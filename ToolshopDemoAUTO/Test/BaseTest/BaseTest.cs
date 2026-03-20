using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using ToolshopDemoAUTO.Genericos.DriverConfig;
using ToolshopDemoAUTO.Reportes;

namespace ToolshopDemoAUTO.Test.BaseTest
{
    public abstract class BaseTest
    {
        protected IWebDriver Driver;

        [SetUp]
        public void Setup()
        {
            ExtentReportManager.CreateTest(TestContext.CurrentContext.Test.Name);

            var options = new ChromeOptions();
            options.AddArgument("--start-maximized");
            Driver = ChromeFactory.CreateDriver(options);
        }

        [TearDown]
        public void TearDown()
        {
            var result = TestContext.CurrentContext.Result;

            if (result.Outcome.Status == NUnit.Framework.Interfaces.TestStatus.Failed)
            {
                ExtentReportManager.LogFail(result.Message);
                ExtentReportManager.LogScreenshot(Driver, "Error en la prueba");
            }
            else if (result.Outcome.Status == NUnit.Framework.Interfaces.TestStatus.Passed)
            {
                ExtentReportManager.LogPass("Prueba aprobada correctamente");
                ExtentReportManager.LogScreenshot(Driver, "Evidencia de prueba aprobada");
            }

            try { Driver.Dispose(); } catch { }

            ExtentReportManager.Flush();
        }
    }
}