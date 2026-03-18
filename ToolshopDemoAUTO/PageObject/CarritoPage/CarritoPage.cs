using OpenQA.Selenium;

namespace ToolshopDemoAUTO.PageObject.CarritoPage
{
    public class CarritoPage : BasePage.BasePage
    {
        private readonly string homeUrl = "https://practicesoftwaretesting.com/#/";
        private By pageHome = By.XPath("//a[normalize-space()='Home']");


        //Selectores para login
        private By tbxEmail = By.Id("email");
        private By tbxPassword = By.Id("password");
        private By btnSubmit = By.XPath("//input[@value='Iniciar sesión']");
        private By pageLogin = By.XPath("//a[normalize-space()='Sign in']");
        //Selectores para el carrito
        private By selectBoltCutters = By.CssSelector(".card[data-test='product-01KKWAKZ4PGT3HBBNK6PFPCG6C']");
        private By addCart = By.Id("btn-add-to-cart");
        private By selectHammer = By.CssSelector(".card[data-test='product-01KKWAKZ5G9NHPY86GAHVEJ2EA']");
        private By productList4 = By.XPath("//a[normalize-space()='4']");
        private By selectGloves = By.CssSelector(".card[data-test='product-01KKVJJVZ2X0BRFZ6QGSWV0NV6']");
        private By productList5 = By.XPath("//a[normalize-space()='5']");
        private By selectDrill = By.CssSelector(".card[data-test='product-01KKWAKZ9BS643TGHXK13VG0SE']");
        private By pageCarrito = By.CssSelector("a[aria-label='cart']");
        private By tbxCantidadProdto = By.XPath("");

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

        public void Login()
        {
            GoToLogin();
            EnterEmail("customer@practicesoftwaretesting.com");
            EnterPassword("welcome01");
            ClickSumbit();
            ClickElement(pageHome);
        }

        public void EnterCantidadProducto(string cantidad)
        {
            WaitforElement(tbxCantidadProdto).Clear();
            _driver.FindElement(By.XPath("//input[@id='quantity-01kkx26qgs9er776mxmx83sy4n']")).SendKeys(cantidad);
        }

        public void FlujoCarrito()
        {
            ClickElement(selectBoltCutters);
            ClickElement(addCart);
            ClickElement(pageHome);
            ClickElement(selectHammer);
            ClickElement(addCart);
            ClickElement(pageHome);
            ClickElement(productList4);
            ClickElement(selectGloves);
            ClickElement(addCart);
            ClickElement(pageHome);
            ClickElement(productList5);
            ClickElement(selectDrill);
            ClickElement(addCart);
            ClickElement(pageHome);
            ClickElement(pageCarrito);
            EnterCantidadProducto("3");
        }
    }
}
