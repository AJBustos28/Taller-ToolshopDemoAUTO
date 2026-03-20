using OpenQA.Selenium;
using ToolshopDemoAUTO.PageObject.LoginPage;
using ToolshopDemoAUTO.Reportes;

namespace ToolshopDemoAUTO.PageObject.CarritoPage
{
    public class CarritoPage : BasePage.BasePage
    {
        private readonly string homeUrl = "https://practicesoftwaretesting.com/#/";
        private By pageHome = By.LinkText("Inicio");


        //Selectores para login
        private By tbxEmail = By.Id("email");
        private By tbxPassword = By.Id("password");
        private By btnSubmit = By.XPath("//input[@value='Iniciar sesión']");
        private By pageLogin = By.LinkText("Iniciar sesión");
        //Selectores para el carrito
        private By selectBoltCutters = By.XPath("/html/body/app-root/div[2]/app-overview/div[3]/div[2]/div[1]/a[3]");
        private By addCart = By.Id("btn-add-to-cart");
        private By selectHammer = By.XPath("/html/body/app-root/div[2]/app-overview/div[3]/div[2]/div[1]/a[7]");
        private By productList4 = By.LinkText("4");
        private By selectGloves = By.XPath("/html/body/app-root/div[2]/app-overview/div[3]/div[2]/div[1]/a[1]");
        private By productList5 = By.LinkText("5");
        private By selectDrill = By.XPath("/html/body/app-root/div[2]/app-overview/div[3]/div[2]/div[1]/a[8]");
        private By pageCarrito = By.XPath("//*[@id=\"navbarSupportedContent\"]/ul/li[5]/a");
        //private By tbxCantidadProdto = By.Id("quantity-01km4srvtscn5vhc6w2338webv");
        private By tbxCantidadProdto = By.CssSelector("input[data-test='product-quantity']");



        public CarritoPage(IWebDriver driver) : base(driver) { }

        public void GoToLogin()
        {
            _driver.Navigate().GoToUrl(homeUrl);
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
            ExtentReportManager.LogInfo("De la pagina incio a la login");
            EnterEmail(email);
            ExtentReportManager.LogInfo("Digitando correo electronico asociado");
            EnterPassword(password);
            ExtentReportManager.LogInfo("Digitando contraseña");
            ClickSumbit();
            ExtentReportManager.LogInfo("Enviamos los datos de login");
        }

        public void EnterCantidadProducto(string cantidad)
        {
            WaitforElement(tbxCantidadProdto).Clear();
            _driver.FindElement(By.CssSelector("input[data-test='product-quantity']")).SendKeys(cantidad);
        }

        public void FlujoCarrito(string email, string password,string cantidad)
        {
            Login(email, password);
            Thread.Sleep(5000);
            ClickElement(pageHome);
            ExtentReportManager.LogInfo("Volvemos a pagina inicio");
            ClickElement(selectBoltCutters);
            ExtentReportManager.LogInfo("Se Ingresa al producto de 'Bolt Cutters'");
            ClickElement(addCart);
            ExtentReportManager.LogInfo("Se añade el producto al carrito");
            Thread.Sleep(5000);
            ClickElement(pageHome);
            ExtentReportManager.LogInfo("Volvemos a pagina inicio");
            ClickElement(selectHammer);
            ExtentReportManager.LogInfo("Se Ingresa al producto de 'Hammer'");
            ClickElement(addCart);
            ExtentReportManager.LogInfo("Se añade el producto al carrito");
            Thread.Sleep(5000);
            ClickElement(pageHome);
            ExtentReportManager.LogInfo("Volvemos a pagina inicio");
            ClickElement(productList4);
            ExtentReportManager.LogInfo("Dirigmos al listado de productos 4");
            Thread.Sleep(2000);
            ClickElement(selectGloves);
            ExtentReportManager.LogInfo("Se Ingresa al producto de 'Gloves'");
            ClickElement(addCart);
            ExtentReportManager.LogInfo("Se añade el producto al carrito");
            Thread.Sleep(5000);
            ClickElement(pageHome);
            ExtentReportManager.LogInfo("Volvemos a pagina inicio");
            Thread.Sleep(3000);
            ClickElement(productList5);
            ExtentReportManager.LogInfo("Dirigmos al listado de productos 5");
            Thread.Sleep(2000);
            ClickElement(selectDrill);
            ExtentReportManager.LogInfo("Se Ingresa al producto de 'Drill'");
            ClickElement(addCart);
            ExtentReportManager.LogInfo("Se añade el producto al carrito");
            Thread.Sleep(5000);
            ClickElement(pageHome);
            ExtentReportManager.LogInfo("Volvemos a pagina inicio");
            ClickElement(pageCarrito);
            ExtentReportManager.LogInfo("Dirigmos a la pagina del carrito");
            Thread.Sleep(5000);
            EnterCantidadProducto(cantidad);
            ExtentReportManager.LogInfo("Se cambia la cantidad de productos en el carrito");
            Thread.Sleep(1500);
        }
    }
}
