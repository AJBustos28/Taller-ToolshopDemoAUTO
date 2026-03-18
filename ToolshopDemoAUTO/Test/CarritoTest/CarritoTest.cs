using ToolshopDemoAUTO.PageObject.CarritoPage;

namespace ToolshopDemoAUTO.Test.CarritoTest
{
    [TestFixture]
    public class CarritoTest : BaseTest.BaseTest
    {
        [Test]
        public void Carrito()
        {
            var CarritoPage = new CarritoPage(Driver);
            CarritoPage.FlujoCarrito();

        }
    }
}
