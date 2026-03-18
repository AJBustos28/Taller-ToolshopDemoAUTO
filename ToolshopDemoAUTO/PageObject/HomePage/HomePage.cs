using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace ToolshopDemoAUTO.PageObject.HomePage
{
    public class HomePage : BasePage.BasePage
    {
        private readonly string homeUrl = "https://practicesoftwaretesting.com/#/";

        //Selectores Busqueda
        private By tbxBusqueda = By.Id("search-query");                             //Caja Busqueda
        private By btnSearch = By.XPath("//button[normalize-space()='Buscar']");    //Buscar Boton
        private By btnClear = By.XPath("//button[normalize-space()='X']");          //Limpiar Busqueda
        

        public HomePage(IWebDriver driver) : base(driver) { }

        public void GoTo()
        {
            _driver.Navigate().GoToUrl(homeUrl);
        }

        #region Flujo de Busqueda

        public void EnterSearch(string search)
        {
            WaitforElement(tbxBusqueda).Clear();
            _driver.FindElement(By.Id("search-query")).SendKeys(search);
        }

        public void ClickSearch()
        {
            ClickElement(btnSearch);
        }

        public void ClearSearch()
        {
            ClickElement(btnClear);
        }

        public void FullSearch(string search)
        {
            GoTo();
            EnterSearch(search);
            ClickSearch();
            Thread.Sleep(5000);
            ClearSearch();
        }

        #endregion

        #region Flujo de filtros por precio y categoria

        //Selectores Filtros por Cateogrias
        private By filtroCatPliers = By.CssSelector("input[value='01KKY8DE6CX2GCS0XVMG7X7DQD']"); //Categoria Pliers de Hand Tools
        private By filtroCatDrill = By.CssSelector("input[value='01KKY8DE6CX2GCS0XVMG7X7DQK']"); //Categoria Drill de Power Tools
        private By filtroMarcaFFT = By.CssSelector("input[value='01KKY8DDSS9A7WVNWDQ1BWTQPD']"); //Filtro de marca forgeflex tools
        private By filtroSostEco = By.CssSelector("input[name='eco_friendly']");  //Filtro por productos sostenibles ecológicos

        public void ClickPliers()
        {
            ClickElement(filtroCatPliers);
            Thread.Sleep(3000);
            ClickElement(filtroCatPliers);
        }
        public void ClickDrill()
        {
            ClickElement(filtroCatDrill);
            Thread.Sleep(3000);
            ClickElement(filtroCatDrill);
        }
        public void ClickMarca()
        {
            ClickElement(filtroMarcaFFT);
            Thread.Sleep(3000);
            ClickElement(filtroMarcaFFT);
        }
        public void ClickSostenible()
        {
            ClickElement(filtroSostEco);
            Thread.Sleep(3000);
            ClickElement(filtroSostEco);
        }

        public void FlujoCategoria()
        {
            GoTo();
            ClickPliers();
            Thread.Sleep(3000);
            ClickDrill();
            Thread.Sleep(3000);
            ClickMarca();
            Thread.Sleep(3000);
            ClickSostenible();
            Thread.Sleep(3000);
        }

        // Selectores Filtro por Precio                  
        private By sliderPrecioBajo = By.XPath("span[aria-label='ngx-slider']");          //Limite a precio mas bajo
        private By sliderPrecioAlto = By.XPath("span[aria-label='ngx-slider-max']");      //Limite a precio mas alto

        public void SeleccionarRangoPrecio(int offsetMin, int offsetMax) 
        {
            GoTo();
            IWebElement minHandle = WaitforElement(sliderPrecioBajo);
            IWebElement maxHandle = WaitforElement(sliderPrecioAlto);

            Actions actions = new Actions(_driver);

            actions.DragAndDropToOffset(minHandle, offsetMin, 0).Perform();
            actions.DragAndDropToOffset(maxHandle, offsetMax, 0).Perform();
        }

        #endregion
    }
}
