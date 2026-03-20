using OpenQA.Selenium;
using ToolshopDemoAUTO.PageObject.LoginPage;
using ToolshopDemoAUTO.Reportes;

namespace ToolshopDemoAUTO.Test.LoginTest
{
    [TestFixture]
    public class LoginTest : BaseTest.BaseTest
    {

        private By ErrorMessage = By.CssSelector(".help-block");

        [Test]
        public void LoginCliente()
        {
            var loginPage = new LoginPage(Driver);
            loginPage.Login("customer@practicesoftwaretesting.com", "welcome01");
            Thread.Sleep(2000);
            ExtentReportManager.LogInfo("Digitamos el correo y contraseña relacionado al usuario cliente");
            string expectedUrl = "https://practicesoftwaretesting.com/account";
            Assert.That(loginPage.GetCurrentUrl(), Is.EqualTo(expectedUrl));

            Thread.Sleep(1500);
        }

        [Test]
        public void LoginAdmin()
        {
            var loginPage = new LoginPage(Driver);
            loginPage.Login("admin@practicesoftwaretesting.com", "welcome01");
            Thread.Sleep(2000);
            ExtentReportManager.LogInfo("Digitamos el correo y contraseña relacionado al usuario administrador");
            string expectedUrl = "https://practicesoftwaretesting.com/admin/dashboard";
            Assert.That(loginPage.GetCurrentUrl(), Is.EqualTo(expectedUrl));

            Thread.Sleep(1500);
        }

        [Test]
        public void LoginIncorrecto()
        {
            var loginPage = new LoginPage(Driver);
            loginPage.Login("admin@practicesoftwaretesting.com", "Welcome01");
            Thread.Sleep(2500);
            ExtentReportManager.LogInfo("Digitamos el correo y una contraseña incorrecta del usuario administrador");
            string expectedUrl = "https://practicesoftwaretesting.com/admin/dashboard";
            Assert.That(loginPage.GetCurrentUrl(), Is.Not.EqualTo(expectedUrl));

            Thread.Sleep(1500);
        }
    }
}