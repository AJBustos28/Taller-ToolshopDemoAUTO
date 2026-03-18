using OpenQA.Selenium;

namespace ToolshopDemoAUTO.PageObject.FavoritosPage
{
    public class FavoritosPage :BasePage.BasePage
    {
        private readonly string homeUrl = "https://practicesoftwaretesting.com/#/";
        private By pageHome = By.XPath("//a[normalize-space()='Home']");

        //Selectores para login
        private By tbxEmail = By.Id("email");
        private By tbxPassword = By.Id("password");
        private By btnSubmit = By.XPath("//input[@value='Iniciar sesión']");
        private By pageLogin = By.XPath("//a[normalize-space()='Sign in']");
        //Selectores para favoritos
        private By productList4 = By.XPath("//a[normalize-space()='4']");
        private By selectPorduct = By.CssSelector(".card[data-test='product-01KKVJJVZ2X0BRFZ6QGSWV0NV6']");
        private By btnFavorito = By.Id("btn-add-to-favorites");
        //Selectores Encontrar Favorito Usuario
        private By menuCliente = By.Id("menu");
        private By pageFavoritos = By.XPath("//a[normalize-space()='My favorites']");


        public FavoritosPage(IWebDriver driver) : base(driver) { }

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

        public void Login()
        {
            GoToLogin();
            EnterEmail("customer@practicesoftwaretesting.com");
            EnterPassword("welcome01");
            ClickSumbit();
        }

        public void ProductoFavorito()
        {
            ClickElement(pageHome);
            ClickElement(productList4);
            ClickElement(selectPorduct);
            ClickElement(btnFavorito);
            ClickElement(menuCliente);
            ClickElement(pageFavoritos);
        }

        public void FlujoFavoritos()
        {
            GoToLogin();
            Login();
            ProductoFavorito();
        }
    }
}
