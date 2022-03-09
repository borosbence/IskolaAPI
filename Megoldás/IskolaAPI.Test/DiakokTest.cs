using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IskolaAPI.Test
{
    [TestClass]
    public class DiakokTest
    {
        [TestMethod]
        public void PostProduct_ShouldReturnSameProduct()
        {
            var controller = new ProductController(new TestStoreAppContext());

            var item = GetDemoProduct();

            var result =
                controller.PostProduct(item) as CreatedAtRouteNegotiatedContentResult<Product>;

            Assert.IsNotNull(result);
            Assert.AreEqual(result.RouteName, "DefaultApi");
            Assert.AreEqual(result.RouteValues["id"], result.Content.Id);
            Assert.AreEqual(result.Content.Name, item.Name);
        }
    }
}
