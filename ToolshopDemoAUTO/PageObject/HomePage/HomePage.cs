using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using ToolshopDemoAUTO.Reportes;

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
            ExtentReportManager.LogInfo("Ingresamos Hammer en la barra de busqueda");
        }

        public void ClickSearch()
        {
            ClickElement(btnSearch);
            ExtentReportManager.LogInfo("Se realiza la busqueda");
        }

        public void ClearSearch()
        {
            ClickElement(btnClear);
            ExtentReportManager.LogInfo("Limpiamos la barra de busqueda");

        }

        public void FullSearch(string search)
        {
            GoTo();
            EnterSearch(search);
            ClickSearch();
            Thread.Sleep(5000);
            ClearSearch();
            Thread.Sleep(2000);
        }

        #endregion

        #region Flujo de filtros por precio y categoria

        //Selectores Filtros por Cateogrias
        private By filtroCatPliers = By.XPath("//*[@id=\"filters\"]/fieldset[1]/div[1]/ul/fieldset/div[5]/label/input"); //Categoria Pliers de Hand Tools
        private By filtroCatDrill = By.XPath("//*[@id=\"filters\"]/fieldset[1]/div[2]/ul/fieldset/div[4]/label/input"); //Categoria Drill de Power Tools
        private By filtroMarcaFFT = By.XPath("//*[@id=\"filters\"]/fieldset[2]/div[1]/label/input"); //Filtro de marca forgeflex tools
        private By filtroSostEco = By.XPath("//*[@id=\"filters\"]/fieldset[3]/div/label/input");  //Filtro por productos sostenibles ecológicos

        public void ClickPliers()
        {
            ClickElement(filtroCatPliers);
            ExtentReportManager.LogInfo("Seleccionamos la categoria Pliers");
            Thread.Sleep(2000);
            ClickElement(filtroCatPliers);
            ExtentReportManager.LogInfo("Quitamos la seleccion de la categoria Pliers");
        }
        public void ClickDrill()
        {
            ClickElement(filtroCatDrill);
            ExtentReportManager.LogInfo("Seleccionamos la categoria Drill");
            Thread.Sleep(2000);
            ClickElement(filtroCatDrill);
            ExtentReportManager.LogInfo("Quitamos la seleccion de la categoria Drill");
        }
        public void ClickMarca()
        {
            ClickElement(filtroMarcaFFT);
            ExtentReportManager.LogInfo("Seleccionamos la marca ForgeFlex Tools");
            Thread.Sleep(2000);
            ClickElement(filtroMarcaFFT);
            ExtentReportManager.LogInfo("Quitamos la seleccion de la marca ForgeFlex Tools");
        }
        public void ClickSostenible()
        {
            ClickElement(filtroSostEco);
            ExtentReportManager.LogInfo("Seleccionamos la categoria de productos ecológicos");
            Thread.Sleep(2000);
            ClickElement(filtroSostEco);
            ExtentReportManager.LogInfo("Seleccionamos la categoria de productos ecológicos");
        }

        public void FlujoCategoria()
        {
            GoTo();
            ClickPliers();
            Thread.Sleep(1500);
            ClickDrill();
            Thread.Sleep(1500);
            ClickMarca();
            Thread.Sleep(1500);
            ClickSostenible();
            Thread.Sleep(1000);
        }

        // Selectores Filtro por Precio                  
        private By sliderPrecioBajo = By.XPath("//*[@id=\"filters\"]/div[1]/ngx-slider/span[5]");          //Limite a precio mas bajo
        private By sliderPrecioAlto = By.XPath("//*[@id=\"filters\"]/div[1]/ngx-slider/span[6]");      //Limite a precio mas alto

        public void SeleccionarRangoPrecio(int offsetMin, int offsetMax) 
        {
            GoTo();
            Thread.Sleep(3000);
            IWebElement minHandle = WaitforElement(sliderPrecioBajo);
            IWebElement maxHandle = WaitforElement(sliderPrecioAlto);

            Actions actions = new Actions(_driver);

            actions.DragAndDropToOffset(minHandle, offsetMin, 0).Perform();
            Thread.Sleep(1500);
            ExtentReportManager.LogInfo("Movemos 40 pixeles el filtro de precio mínimo");
            actions.DragAndDropToOffset(maxHandle, offsetMax, 0).Perform();
            ExtentReportManager.LogInfo("Movemos 80 pixeles el filtro de precio máximo");
            Thread.Sleep(3000);
        }

        #endregion
    }
}
