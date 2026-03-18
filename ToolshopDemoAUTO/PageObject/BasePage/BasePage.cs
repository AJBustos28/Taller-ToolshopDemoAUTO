using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace ToolshopDemoAUTO.PageObject.BasePage
{
    public class BasePage
    {
        protected IWebDriver _driver;
        protected WebDriverWait wait;

        public BasePage(IWebDriver driver)
        {
            _driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        protected IWebElement WaitforElement(By locator)
        {
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(locator));
        }
        protected void ClickElement(By locator)
        {
            WaitforElement(locator).Click();
        }
        protected void EnviarTexto(By locator, string texto)
        {
            WaitforElement(locator).SendKeys(texto); // Espera a que el elemento sea visible y luego hace clic en él
        }

        public string GetCurrentUrl()
        {
            return _driver.Url;
        }
    }
}
