using OpenQA.Selenium;
using ToolshopDemoAUTO.PageObject.LoginPage;

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
            Thread.Sleep(5000);
            string expectedUrl = "https://practicesoftwaretesting.com/account";
            Assert.That(loginPage.GetCurrentUrl(), Is.EqualTo(expectedUrl));

            Thread.Sleep(3000);
        }

        [Test]
        public void LoginAdmin()
        {
            var loginPage = new LoginPage(Driver);
            loginPage.Login("admin@practicesoftwaretesting.com", "welcome01");
            Thread.Sleep(5000);
            string expectedUrl = "https://practicesoftwaretesting.com/admin/dashboard";
            Assert.That(loginPage.GetCurrentUrl(), Is.EqualTo(expectedUrl));

            Thread.Sleep(5000);
        }

        [Test]
        public void LoginIncorrecto()
        {
            var loginPage = new LoginPage(Driver);
            loginPage.Login("admin@practicesoftwaretesting.com", "Welcome01");

            string expectedUrl = "https://practicesoftwaretesting.com/admin/dashboard";
            Assert.That(loginPage.GetCurrentUrl(), Is.Not.EqualTo(expectedUrl));

            Thread.Sleep(5000);
        }
    }
}