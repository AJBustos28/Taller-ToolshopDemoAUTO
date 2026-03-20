using ToolshopDemoAUTO.PageObject.PagoPage;

namespace ToolshopDemoAUTO.Test.PagoTest
{
    [TestFixture]
    public class PagoTest : BaseTest.BaseTest
    {
        [Test]
        public void PagosTest()
        {
            var PagoPage = new PagoPage(Driver);
            PagoPage.FlujoPago("customer2@practicesoftwaretesting.com","welcome01","Rodeo Drive", "Los Angeles", "California", "USA", "90210");
        }
    }
}
