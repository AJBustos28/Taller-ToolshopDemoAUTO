using ToolshopDemoAUTO.PageObject.ContactPage;

namespace ToolshopDemoAUTO.Test.ContactTest
{
    [TestFixture]
    public class ContactTest : BaseTest.BaseTest
    {
        [Test]
        public void ContactoTest()
        {
            var ContactPage = new ContactPage(Driver);
            ContactPage.FullContacto("Josue", "Peralta", "jptesting@gmail.com", "Garantía","Mi pedido llego roto y no funciona, quiero una devolución"); 
            //Opciones de asunto: Atención al cliente, Webmaster, Devolución, Pagos, Garantía, Estado de mi pedido
        }
    }
}
