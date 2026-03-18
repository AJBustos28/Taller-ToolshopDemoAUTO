using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace ToolshopDemoAUTO.PageObject.ContactPage
{
    public class ContactPage : BasePage.BasePage
    {
        private readonly string homeUrl = "https://practicesoftwaretesting.com/#/";

        //Selectores
        private By tbxNombre = By.Id("first_name");
        private By tbxApellido = By.Id("last_name");
        private By tbxCorreo = By.Id("email");
        private By selectAsunto = By.Id("subject");                       //Asunto del mensaje
        private By tbxMensaje = By.Id("message");
        private By btnEnviar = By.XPath("//input[@value='Enviar']");
        private By pageContact = By.XPath("//a[normalize-space()='Contact']");
        //Selectores login admin
        private By tbxEmail = By.Id("email");
        private By tbxPassword = By.Id("password");
        private By btnSubmit = By.XPath("//input[@value='Iniciar sesión']");
        private By pageLogin = By.XPath("//a[normalize-space()='Sign in']");
        private By menuAdmin = By.Id("menu");
        private By pageMessages = By.XPath("//a[normalize-space()='Messages']");

        public ContactPage(IWebDriver driver) : base(driver) { }

        public void GoToContact()
        {
            _driver.Navigate().GoToUrl(homeUrl);
            ClickElement(pageContact);
        }

        public void EnterName(string nombre)
        {
            WaitforElement(tbxNombre).Clear();
            _driver.FindElement(By.Id("first_name")).SendKeys(nombre);
        }

        public void EnterApellido(string apellido)
        {
            WaitforElement(tbxApellido).Clear();
            _driver.FindElement(By.Id("last_name")).SendKeys(apellido);
        }

        public void EnterCorreo(string email)
        {
            WaitforElement(tbxCorreo).Clear();
            _driver.FindElement(By.Id("email")).SendKeys(email);
        }

        public void ComboBoxAsunto(string asunto)
        {
            var selectElement = new SelectElement(WaitforElement(selectAsunto));
            selectElement.SelectByText(asunto);
        }

        public void EnterMensaje(string mensaje)
        {
            WaitforElement(tbxMensaje).Clear();
            _driver.FindElement(By.Id("message")).SendKeys(mensaje);
        }


        public void ClickSubmit()
        {
            ClickElement(btnEnviar);
        }

        public void GoToLogin()
        {
            ClickElement(pageLogin);
        }

        public void EnterEmail(string email)
        {
            WaitforElement(tbxEmail).Clear();
            _driver.FindElement(By.Id("email")).SendKeys(email);
        }

        public void EnterPassword(string password)
        {
            WaitforElement(tbxPassword).Clear();
            _driver.FindElement(By.Id("password")).SendKeys(password);
        }
        public void ClickSumbit()
        {
            ClickElement(btnSubmit);
        }

        public void Login()
        {
            GoToLogin();
            EnterEmail("admin@practicesoftwaretesting.com");
            EnterPassword("welcome01");
            ClickSumbit();
        }

        public void CheckExistence()
        {
            ClickElement(menuAdmin);
            ClickElement(pageMessages);
        }

        public void FullContacto(string name, string apellido, string email, string asunto, string mensaje)
        {
            GoToContact();
            EnterName(name);
            EnterApellido(apellido);
            EnterCorreo(email);
            ComboBoxAsunto(asunto);
            EnterMensaje(mensaje);
            ClickSubmit();
            GoToLogin();
            Login();
            CheckExistence();
        }
    }
}
