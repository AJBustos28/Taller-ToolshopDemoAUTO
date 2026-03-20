using ToolshopDemoAUTO.PageObject.FavoritosPage;

namespace ToolshopDemoAUTO.Test.FavoritosTest
{
    [TestFixture]
    public class FavoritosTest : BaseTest.BaseTest
    {
        [Test]
        public void FavoritoTest()
        {
            var FavoritosPage = new FavoritosPage(Driver);
            FavoritosPage.FlujoFavoritos("customer2@practicesoftwaretesting.com", "welcome01");
        }
    }
}