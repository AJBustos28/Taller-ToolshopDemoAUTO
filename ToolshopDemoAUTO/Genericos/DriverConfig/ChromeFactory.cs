using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace ToolshopDemoAUTO.Genericos.DriverConfig
{
    public class ChromeFactory
    {
        public static IWebDriver CreateDriver(ChromeOptions options)
        {
            return new ChromeDriver(options);
        }
    }
}
