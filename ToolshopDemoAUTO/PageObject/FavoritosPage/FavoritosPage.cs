using OpenQA.Selenium;
using ToolshopDemoAUTO.Reportes;

namespace ToolshopDemoAUTO.PageObject.FavoritosPage
{
    public class FavoritosPage :BasePage.BasePage
    {
        private readonly string homeUrl = "https://practicesoftwaretesting.com/#/";
        private By pageHome = By.LinkText("Inicio");

        //Selectores para login
        private By tbxEmail = By.Id("email");
        private By tbxPassword = By.Id("password");
        private By btnSubmit = By.XPath("//input[@value='Iniciar sesión']");
        private By pageLogin = By.LinkText("Iniciar sesión");
        //Selectores para favoritos
        private By productList4 = By.LinkText("4");
        private By selectProduct = By.XPath("/html/body/app-root/div[2]/app-overview/div[3]/div[2]/div[1]/a[1]");
        private By btnFavorito = By.Id("btn-add-to-favorites");
        //Selectores Encontrar Favorito Usuario
        private By menuCliente = By.Id("menu");
        private By pageFavoritos = By.LinkText("Mis favoritos");


        public FavoritosPage(IWebDriver driver) : base(driver) { }

        public void GoToLogin()
        {
            _driver.Navigate().GoToUrl(homeUrl);
            ClickElement(pageLogin);
            ExtentReportManager.LogInfo("Dirigimos a la pagina de login");
        }

        public void EnterEmail(string email)
        {
            WaitforElement(tbxEmail).Clear();
            _driver.FindElement(By.Id("email")).SendKeys(email);
            ExtentReportManager.LogInfo("Ingresamos el correo asociado al cliente");
        }

        public void EnterPassword(string password)
        {
            WaitforElement(tbxPassword).Clear();
            _driver.FindElement(By.Id("password")).SendKeys(password);
            ExtentReportManager.LogInfo("Ingresamos la contraseña asociada al cliente");
        }
        public void ClickSumbit()
        {
            ClickElement(btnSubmit);
            ExtentReportManager.LogInfo("Enviamos los datos");
        }

        public void Login(string email, string password)
        {
            GoToLogin();
            EnterEmail(email);
            EnterPassword(password);
            ClickSumbit();
            Thread.Sleep(5000);
        }

        public void ProductoFavorito()
        {
            ClickElement(pageHome);
            ExtentReportManager.LogInfo("Volvemos a la pagina de inicio");
            Thread.Sleep(1500);
            ClickElement(productList4);
            ExtentReportManager.LogInfo("Dirigimos al listado de productos 4");
            Thread.Sleep(1500);
            ClickElement(selectProduct);
            ExtentReportManager.LogInfo("Elegimos el producto");
            Thread.Sleep(1500);
            ClickElement(btnFavorito);
            ExtentReportManager.LogInfo("Añadimos el producto a favoritos mediante el ´botón");
            Thread.Sleep(2000);
            ClickElement(menuCliente);
            ExtentReportManager.LogInfo("Abrimos menu de usuario");
            Thread.Sleep(1000);
            ClickElement(pageFavoritos);
            ExtentReportManager.LogInfo("Dirigimos a la pagina de favoritos");
            Thread.Sleep(3000);
        }

        public void FlujoFavoritos(string email, string password)
        {
            GoToLogin();
            Login(email, password);
            ProductoFavorito();
        }
    }
}
