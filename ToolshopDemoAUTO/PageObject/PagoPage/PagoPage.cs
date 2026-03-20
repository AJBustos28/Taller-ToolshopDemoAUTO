using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using ToolshopDemoAUTO.Reportes;

namespace ToolshopDemoAUTO.PageObject.PagoPage
{
    public class PagoPage : BasePage.BasePage
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
        private By pageCarrito = By.XPath("//*[@id=\"navbarSupportedContent\"]/ul/li[5]/a");
        //Selectores pagos
        private By btnCheckout1 = By.XPath("/html/body/app-root/div[2]/app-checkout/aw-wizard/div/aw-wizard-step[1]/app-cart/div/div/button[2]");
        private By btnCheckout2 = By.XPath("/html/body/app-root/div[2]/app-checkout/aw-wizard/div/aw-wizard-step[2]/app-login/div/div/div/div/button");
        private By tbxCalle = By.Id("street");
        private By tbxCiudad = By.Id("city");
        private By tbxEstado = By.Id("state");
        private By tbxPais = By.Id("country");
        private By tbxCodPostal = By.Id("postal_code");
        private By btnCheckout3 = By.XPath("/html/body/app-root/div[2]/app-checkout/aw-wizard/div/aw-wizard-step[3]/app-address/div/div/div/div/button");
        private By drpdwnMetodoPago = By.Id("payment-method");
        private By drpdwnCuotasMensual = By.Id("monthly_installments");
        private By btnConfirmPago = By.XPath("/html/body/app-root/div[2]/app-checkout/aw-wizard/div/aw-wizard-completion-step/app-payment/div/div/div/div/button");
        private By menuCliente = By.Id("menu");
        private By pageFactura = By.LinkText("Mis facturas");


        public PagoPage(IWebDriver driver) : base(driver) { }

        public void GoToLogin()
        {
            _driver.Navigate().GoToUrl(homeUrl);
            ClickElement(pageLogin);
            Thread.Sleep(1500);
            ExtentReportManager.LogInfo("Dirigimos a la pagina login");
        }

        public void EnterEmail(string email)
        {
            WaitforElement(tbxEmail).Clear();
            _driver.FindElement(By.Id("email")).SendKeys(email);
            ExtentReportManager.LogInfo("Digitamos el correo asociado a cliente");
        }

        public void EnterPassword(string password)
        {
            WaitforElement(tbxPassword).Clear();
            _driver.FindElement(By.Id("password")).SendKeys(password);
            ExtentReportManager.LogInfo("Digitamos la contraseña asociada al cliente");
        }
        public void ClickSumbit()
        {
            ClickElement(btnSubmit);
            ExtentReportManager.LogInfo("Enviamos los datos para ingresar a la cuenta");
        }


        //Evento de login
        public void Login(string email, string password)
        {
            GoToLogin();
            EnterEmail(email);
            EnterPassword(password);
            ClickSumbit();
            Thread.Sleep(5000);
            ClickElement(pageHome);
            ExtentReportManager.LogInfo("Dirigimos a la pagina de inicio");
        }


        //Evento llenar carrito
        public void LlenarCarrito()
        {
            ClickElement(selectBoltCutters);
            ExtentReportManager.LogInfo("Seleccionamos el producto Bolt Cutter");
            ClickElement(addCart);
            ExtentReportManager.LogInfo("Agregamos el producto al carrito");
            Thread.Sleep(2500);
            ClickElement(pageHome);
            ExtentReportManager.LogInfo("Volvemos a la pagina de inicio");
            ClickElement(selectHammer);
            ExtentReportManager.LogInfo("Seleccionamos el producto Hammer");
            ClickElement(addCart);
            ExtentReportManager.LogInfo("Agregamos el producto al carrito");
            Thread.Sleep(2500);
            ClickElement(pageCarrito);
            ExtentReportManager.LogInfo("Dirigimos a la pagina de carrito");
            ClickElement(btnCheckout1);
            ExtentReportManager.LogInfo("Continuamos por el flujo de compra");
            Thread.Sleep(1500);
            ClickElement(btnCheckout2);
            ExtentReportManager.LogInfo("Continuamos por el flujo de compra");
            Thread.Sleep(1500);
        }

        public void EnterStreet(string street)
        {
            WaitforElement(tbxCalle).Clear();
            _driver.FindElement(By.Id("street")).SendKeys(street);
            ExtentReportManager.LogInfo("Ingresamos la calle asociada a la direccion de pago");
        }
        public void EnterCity(string city)
        {
            WaitforElement(tbxCiudad).Clear();
            _driver.FindElement(By.Id("city")).SendKeys(city);
            ExtentReportManager.LogInfo("Ingresamos la ciudad asociada a la direccion de pago");
        }
        public void EnterState(string state)
        {
            WaitforElement(tbxEstado).Clear();
            _driver.FindElement(By.Id("state")).SendKeys(state);
            ExtentReportManager.LogInfo("Ingresamos el estado asociado a la direccion de pago");
        }
        public void EnterCountry(string country)
        {
            WaitforElement(tbxPais).Clear();
            _driver.FindElement(By.Id("country")).SendKeys(country);
            ExtentReportManager.LogInfo("Ingresamos eñ pais asociado a la direccion de pago");
        }
        public void EnterPostalCode(string postal_code)
        {
            WaitforElement(tbxCodPostal).Clear();
            _driver.FindElement(By.Id("postal_code")).SendKeys(postal_code);
            ExtentReportManager.LogInfo("Ingresamos el codigo postal asociado a la direccion de pago");
        }

        //Evento datos de entrega
        public void LlenarDatosPedido(string street, string city, string state, string country, string postal_code)
        {
            EnterStreet(street);
            EnterCity(city);
            EnterState(state);
            EnterCountry(country);
            EnterPostalCode(postal_code);
            Thread.Sleep(2000);
            ClickElement(btnCheckout3);
            ExtentReportManager.LogInfo("Continuamos por el flujo de compra");
            Thread.Sleep(2500);
        }

        public void SeleccionarMetodoPago()
        {
            IWebElement dropdown = WaitforElement(drpdwnMetodoPago);
            SelectElement select = new SelectElement(dropdown);
            select.SelectByText("Buy Now Pay Later");
            Thread.Sleep(2000);
            ExtentReportManager.LogInfo("Seleccionamos el metodo de pago");
        }

        public void SeleccionarCuotaMensual()
        {
            IWebElement dropdown = WaitforElement(drpdwnCuotasMensual);
            SelectElement select = new SelectElement(dropdown);
            select.SelectByValue("9");
            Thread.Sleep(2000);
            ExtentReportManager.LogInfo("Seleccionamos la cuota mensual");
        }

        //Evento Realizar pago y revisar factura de compra
        public void RealizarPago()
        {
            SeleccionarMetodoPago();
            SeleccionarCuotaMensual();
            ClickElement(btnConfirmPago);
            Thread.Sleep(5000);
            ClickElement(menuCliente);
            Thread.Sleep(300);
            ClickElement(pageFactura);
            Thread.Sleep(4500);
        }

        public void FlujoPago(string email, string password, string street, string city, string state, string country, string postal_code)
        {
            Login(email, password);
            LlenarCarrito();
            LlenarDatosPedido(street, city, state, country, postal_code);
            RealizarPago();
        }
    }
}
