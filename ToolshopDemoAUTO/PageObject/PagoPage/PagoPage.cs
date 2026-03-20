using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using ToolshopDemoAUTO.Reportes;
namespace ToolshopDemoAUTO.PageObject.PagoPage
{
    public class PagoPage : BasePage.BasePage
    {
        private readonly string homeUrl = "https://practicesoftwaretesting.com/#/";
        // Login
        private By pageHome = By.LinkText("Inicio");
        private By tbxEmail = By.Id("email");
        private By tbxPassword = By.Id("password");
        private By btnSubmit = By.XPath("//input[@value='Iniciar sesión']");
        private By pageLogin = By.LinkText("Iniciar sesión");
        // Buscar Productos y llenar carrito
        private By selectBoltCutters = By.XPath("/html/body/app-root/div[2]/app-overview/div[3]/div[2]/div[1]/a[3]");
        private By selectHammer = By.XPath("/html/body/app-root/div[2]/app-overview/div[3]/div[2]/div[1]/a[7]");
        private By addCart = By.Id("btn-add-to-cart");
        private By pageCarrito = By.XPath("//*[@id=\"navbarSupportedContent\"]/ul/li[5]/a");
        // Checkout
        private By btnCheckout1 = By.XPath("/html/body/app-root/div[2]/app-checkout/aw-wizard/div/aw-wizard-step[1]/app-cart/div/div/button[2]");
        private By btnCheckout2 = By.XPath("/html/body/app-root/div[2]/app-checkout/aw-wizard/div/aw-wizard-step[2]/app-login/div/div/div/div/button");
        // Dirección de pago
        private By tbxCalle = By.Id("street");
        private By tbxCiudad = By.Id("city");
        private By tbxEstado = By.Id("state");
        private By tbxPais = By.Id("country");
        private By tbxCodPostal = By.Id("postal_code");
        private By btnCheckout3 = By.XPath("/html/body/app-root/div[2]/app-checkout/aw-wizard/div/aw-wizard-step[3]/app-address/div/div/div/div/button");
        // Metodo de Pago
        private By drpdwnMetodoPago = By.Id("payment-method");
        private By drpdwnCuotasMensual = By.Id("monthly_installments");
        private By btnConfirmPago = By.XPath("/html/body/app-root/div[2]/app-checkout/aw-wizard/div/aw-wizard-completion-step/app-payment/div/div/div/div/button");        // Verificar Factura
            private By menuCliente = By.Id("menu");
        private By pageFactura = By.LinkText("Mis facturas");
        public PagoPage(IWebDriver driver) : base(driver) { }
        private WebDriverWait Wait => new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
        
        // Login
        public void Login(string email, string password)
        {
            _driver.Navigate().GoToUrl(homeUrl);
            ClickElement(pageLogin);
            Wait.Until(ExpectedConditions.ElementIsVisible(tbxEmail)).SendKeys(email);
            ExtentReportManager.LogInfo("Digitamos el email asociado a cliente");
            _driver.FindElement(tbxPassword).SendKeys(password);
            ExtentReportManager.LogInfo("Digitamos la contraseña asociada al cliente");
            ClickElement(btnSubmit);
            ExtentReportManager.LogInfo("Iniciamos sesión como cliente");
            Thread.Sleep(5000);
            Wait.Until(ExpectedConditions.ElementIsVisible(pageHome));
            ClickElement(pageHome);
            ExtentReportManager.LogInfo("Volvemos a pagina de inicio");
        }
        // Carrito
        public void LlenarCarrito()
        {
            ClickElement(selectBoltCutters);
            ExtentReportManager.LogInfo("Seleccionamos el producto");
            ClickElement(addCart);
            ExtentReportManager.LogInfo("Añadimos el producto a carrito");
            Thread.Sleep(2500);
            ClickElement(pageHome);
            ExtentReportManager.LogInfo("Volvemos a la pagina de inicio");
            ClickElement(selectHammer);
            ExtentReportManager.LogInfo("Seleccionamos el producto");
            ClickElement(addCart);
            ExtentReportManager.LogInfo("Añadimos el producto a carrito");
            Thread.Sleep(3000);
            ClickElement(pageHome);
            ExtentReportManager.LogInfo("Volvemos a la pagina de inicio");
            Thread.Sleep(3000);
            ClickElement(pageCarrito);
            ExtentReportManager.LogInfo("Vamos a la pagina de carrito");
            Thread.Sleep(2500);
            Wait.Until(ExpectedConditions.ElementToBeClickable(btnCheckout1)).Click();
            ExtentReportManager.LogInfo("Continuamos del carrito a pago");
            Thread.Sleep(1500);
            Wait.Until(ExpectedConditions.ElementToBeClickable(btnCheckout2)).Click();
            ExtentReportManager.LogInfo("Continuamos a pago de verificación de login");
            Thread.Sleep(1500);
        }
        // Dirección de pago
        public void LlenarDatosPedido(string street, string city, string state, string country, string postal_code)
        {
            IWebElement calle = Wait.Until(ExpectedConditions.ElementIsVisible(tbxCalle));
            calle.Clear();
            calle.SendKeys(street);
            ExtentReportManager.LogInfo("Digitamos la calle de la dirección de pago");

            IWebElement ciudad = _driver.FindElement(tbxCiudad);
            ciudad.Clear();
            ciudad.SendKeys(city);
            ExtentReportManager.LogInfo("Digitamos la ciudad de la dirección de pago");

            IWebElement estado = _driver.FindElement(tbxEstado);
            estado.Clear();
            estado.SendKeys(state);
            ExtentReportManager.LogInfo("Digitamos el estado de la dirección de pago");

            IWebElement pais = _driver.FindElement(tbxPais);
            pais.Clear();
            pais.SendKeys(country);
            ExtentReportManager.LogInfo("Digitamos el país de la dirección de pago");

            IWebElement codPostal = _driver.FindElement(tbxCodPostal);
            codPostal.Clear();
            codPostal.SendKeys(postal_code);
            ExtentReportManager.LogInfo("Digitamos el código postal de la dirección de pago");

            Thread.Sleep(2000);
            Wait.Until(ExpectedConditions.ElementToBeClickable(btnCheckout3)).Click();
            ExtentReportManager.LogInfo("Continuamos a pago de dirección de pago");
            Thread.Sleep(2000);

        }
        // Método de pago
        public void SeleccionarMetodoPago()
        {
            ClickElement(drpdwnMetodoPago);
            ExtentReportManager.LogInfo("Abrimos las opciones de método de pago");
            IWebElement dropdown = Wait.Until(ExpectedConditions.ElementIsVisible(drpdwnMetodoPago));
            Wait.Until(d => new SelectElement(dropdown).Options.Count > 1);
            SelectElement select = new SelectElement(dropdown);
            Thread.Sleep(2000);
            foreach (var option in select.Options)
            {
                if (option.Text.Contains("paga después"))
                {
                    option.Click();
                    break;
                }
            }
            ExtentReportManager.LogInfo("Seleccionamos la opción: compro ahora pago después");
            ClickElement(drpdwnMetodoPago);
            Thread.Sleep(2000);
            
        }
        public void SeleccionarCuotaMensual()
        {
            ClickElement(drpdwnCuotasMensual);
            ExtentReportManager.LogInfo("Abrimos las opciones de cuotas mensuales");
            IWebElement dropdown = Wait.Until(ExpectedConditions.ElementIsVisible(drpdwnCuotasMensual));
            SelectElement select = new SelectElement(dropdown);
            Thread.Sleep(2000);
            select.SelectByValue("9");
            ClickElement(drpdwnCuotasMensual);
            ExtentReportManager.LogInfo("Seleccionamos la cuota mensual de 9 meses");
        }
        // Pago
        public void RealizarPago()
        {
            SeleccionarMetodoPago();
            SeleccionarCuotaMensual();
            Thread.Sleep(3000);
            Wait.Until(ExpectedConditions.ElementToBeClickable(btnConfirmPago)).Click();
            ExtentReportManager.LogInfo("Confirmamos la compra");
            Thread.Sleep(3000);
            Wait.Until(ExpectedConditions.ElementToBeClickable(btnConfirmPago)).Click();
            ExtentReportManager.LogInfo("Volvemos a confirmar la compra");
            Thread.Sleep(2500);
            Wait.Until(ExpectedConditions.ElementToBeClickable(menuCliente)).Click();
            ExtentReportManager.LogInfo("Abrimos el menu de usuario");
            Thread.Sleep(1500);
            Wait.Until(ExpectedConditions.ElementToBeClickable(pageFactura)).Click();
            ExtentReportManager.LogInfo("Verificamos la factura por calle y fecha");
            Thread.Sleep(5000);
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