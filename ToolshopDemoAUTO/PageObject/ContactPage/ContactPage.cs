using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using ToolshopDemoAUTO.Reportes;

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
        private By pageContact = By.LinkText("Contacto"); 
        //Selectores login admin
        private By tbxEmail = By.Id("email");
        private By tbxPassword = By.Id("password");
        private By btnSubmit = By.XPath("//input[@value='Iniciar sesión']");
        private By pageLogin = By.LinkText("Iniciar sesión");
        private By menuAdmin = By.Id("menu");
        private By pageMessages = By.LinkText("Messages");

        public ContactPage(IWebDriver driver) : base(driver) { }

        public void GoToContact()
        {
            _driver.Navigate().GoToUrl(homeUrl);
            Thread.Sleep(1500);
            ClickElement(pageContact);
            ExtentReportManager.LogInfo("Dirigimos a pagina Contacto");
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

        public void EnterCorreo(string correo)
        {
            WaitforElement(tbxCorreo).Clear();
            _driver.FindElement(By.Id("email")).SendKeys(correo);
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

        public void Login(string email, string password)
        {
            GoToLogin();
            EnterEmail(email);
            ExtentReportManager.LogInfo("Digitamos el correo de usuario admin");
            EnterPassword(password);
            ExtentReportManager.LogInfo("Digitamos la contraseña de usuario admin");
            ClickSumbit();
        }

        public void CheckExistence()
        {
            ClickElement(menuAdmin);
            Thread.Sleep(3000);
            ClickElement(pageMessages);
            Thread.Sleep(5000);
        }

        public void FullContacto(string name, string apellido, string correo, string asunto, string mensaje, string email, string password)
        {
            GoToContact();
            EnterName(name);
            ExtentReportManager.LogInfo("Digitamos el nombre en el campo nombre");
            EnterApellido(apellido);
            ExtentReportManager.LogInfo("Digitamos el apellido en el campo apellido");
            EnterCorreo(correo);
            ExtentReportManager.LogInfo("Digitamos el correo en el campo correo");
            Thread.Sleep(1500);
            ComboBoxAsunto(asunto);
            ExtentReportManager.LogInfo("Elegimos el asunto del mensaje");
            EnterMensaje(mensaje);
            ExtentReportManager.LogInfo("Digitamos la razon/descripción del mensaje");
            Thread.Sleep(1500);
            ClickSubmit();
            ExtentReportManager.LogInfo("Enviamos el mensaje");
            Thread.Sleep(2500);
            GoToLogin();
            ExtentReportManager.LogInfo("Dirigimos a la pagina login");
            Login(email, password);
            Thread.Sleep(3000);
            CheckExistence();
            ExtentReportManager.LogInfo("Revisamos la existencia del mensaje realizado");
        }
    }
}
