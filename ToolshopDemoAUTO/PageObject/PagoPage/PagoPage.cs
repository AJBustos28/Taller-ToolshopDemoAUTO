using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace ToolshopDemoAUTO.PageObject.PagoPage
{
    public class PagoPage : BasePage.BasePage
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
        private By pageCarrito = By.CssSelector("a[aria-label='cart']");
        private By tbxCantidadProducto = By.XPath("//input[@id='quantity-01kkx26qgs9er776mxmx83sy4n']");
        //Selectores pagos
        private By btnCheckout1 = By.XPath("//div[@class='d-flex justify-content-between']" +
                                              "//button[@type='button'][normalize-space()='Proceed to checkout']");
        private By btnCheckout2 = By.XPath("//app-login//button[@type='button'][normalize-space()='Proceed to checkout']");
        private By tbxCalle = By.Id("street");
        private By tbxCiudad = By.Id("city");
        private By tbxEstado = By.Id("state");
        private By tbxPais = By.Id("country");
        private By tbxCodPostal = By.Id("postal_code");
        private By btnCheckout3 = By.XPath("//app-address//button[@type='button'][normalize-space()='Proceed to checkout']");
        private By drpdwnMetodoPago = By.Id("payment-method");
        private By drpdwnCuotasMensual = By.Id("monthly_installments");
        private By btnConfirmPago = By.XPath("//button[normalize-space()='Confirm']");
        private By menuCliente = By.Id("menu");
        private By pageFactura = By.XPath("//a[normalize-space()='My invoices']");


        public PagoPage(IWebDriver driver) : base(driver) { }

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


        //Evento de login
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
            WaitforElement(tbxCantidadProducto).Clear();
            _driver.FindElement(By.XPath("//input[@id='quantity-01kkx26qgs9er776mxmx83sy4n']")).SendKeys(cantidad);
        }

        //Evento llenar carrito
        public void LlenarCarrito()
        {
            ClickElement(selectBoltCutters);
            ClickElement(addCart);
            ClickElement(pageHome);
            ClickElement(selectHammer);
            ClickElement(addCart);
            ClickElement(pageCarrito);
            EnterCantidadProducto("3");
            ClickElement(btnCheckout1);
            ClickElement(btnCheckout2);
        }

        public void EnterStreet(string street)
        {
            WaitforElement(tbxCalle).Clear();
            _driver.FindElement(By.Id("street")).SendKeys(street);
        }
        public void EnterCity(string city)
        {
            WaitforElement(tbxCiudad).Clear();
            _driver.FindElement(By.Id("city")).SendKeys(city);
        }
        public void EnterState(string state)
        {
            WaitforElement(tbxEstado).Clear();
            _driver.FindElement(By.Id("state")).SendKeys(state);
        }
        public void EnterCountry(string country)
        {
            WaitforElement(tbxPais).Clear();
            _driver.FindElement(By.Id("country")).SendKeys(country);
        }
        public void EnterPostalCode(string postal_code)
        {
            WaitforElement(tbxCodPostal).Clear();
            _driver.FindElement(By.Id("postal_code")).SendKeys(postal_code);
        }

        //Evento datos de entrega
        public void LlenarDatosPedido(string street, string city, string state, string country, string postal_code)
        {
            EnterStreet(street);
            EnterCity(city);
            EnterState(state);
            EnterCountry(country);
            EnterPostalCode(postal_code);
            ClickElement(btnCheckout3);
        }

        public void SeleccionarMetodoPago()
        {
            IWebElement dropdown = WaitforElement(drpdwnMetodoPago);
            SelectElement select = new SelectElement(dropdown);
            select.SelectByText("Buy Now Pay Later"); 
        }

        public void SeleccionarCuotaMensual()
        {
            IWebElement dropdown = WaitforElement(drpdwnCuotasMensual);
            SelectElement select = new SelectElement(dropdown);
            select.SelectByValue("9");
        }

        //Evento Realizar pago y revisar factura de compra
        public void RealizarPago()
        {
            SeleccionarMetodoPago();
            SeleccionarCuotaMensual();
            ClickElement(btnConfirmPago);
            ClickElement(menuCliente);
            ClickElement(pageFactura);
        }

        public void FlujoPago(string street, string city, string state, string country, string postal_code)
        {
            Login();
            LlenarCarrito();
            LlenarDatosPedido(street, city, state, country, postal_code);
            RealizarPago();
        }
    }
}
