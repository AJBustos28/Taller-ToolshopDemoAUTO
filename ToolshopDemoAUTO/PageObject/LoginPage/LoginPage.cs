using OpenQA.Selenium;
using ToolshopDemoAUTO.Reportes;

namespace ToolshopDemoAUTO.PageObject.LoginPage
{
    public class LoginPage : BasePage.BasePage
    {
        private readonly string homeUrl = "https://practicesoftwaretesting.com/auth/login";

        //Selectores
        private By tbxEmail = By.Id("email");
        private By tbxPassword = By.Id("password");
        private By btnSubmit = By.XPath("//input[@value='Iniciar sesión']");
        private By pageLogin = By.LinkText("Iniciar sesión");


        public LoginPage(IWebDriver driver) : base(driver) { }

        public void GoToLogin()
        {
            _driver.Navigate().GoToUrl(homeUrl);
            Thread.Sleep(2000);
            ClickElement(pageLogin);
        }

        public void EnterEmail(string email)
        {
            WaitforElement(tbxEmail).Clear();
            _driver.FindElement(By.Id("email")).SendKeys(email);
        }

        public void EnterPassword (string password)
        {
            WaitforElement(tbxPassword).Clear();
            _driver.FindElement(By.Id("password")).SendKeys(password);
        }
        public void ClickSumbit()
        {
            ClickElement(btnSubmit);
        }
        
        public void Login(string email, string password)
        {
            GoToLogin();
            EnterEmail(email);
            EnterPassword(password);
            ClickSumbit();
        }
    }
}
