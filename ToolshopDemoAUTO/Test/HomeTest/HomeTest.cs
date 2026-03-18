using ToolshopDemoAUTO.PageObject.HomePage;

namespace ToolshopDemoAUTO.Test.HomeTest
{
    [TestFixture]
    public class HomeTest : BaseTest.BaseTest
    {
        [Test] 
        public void BusquedaTest()
        {
            var HomePage = new HomePage(Driver);
            HomePage.FullSearch("Hammer");
        }

        [Test]
        public void FiltroCategoriaTest() 
        {
            var HomePage = new HomePage(Driver);
            HomePage.FlujoCategoria();
        }

        [Test]
        public void FiltroPrecioTest()
        {
            var HomePage = new HomePage(Driver);
            HomePage.SeleccionarRangoPrecio(40, 80);
        }
    }
}
