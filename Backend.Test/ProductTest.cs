using Backend;

namespace Backend.Test;

[TestClass]
public class ProductTest
{
    [TestMethod]
    public void CreateNewProductTest()
    {
        // Act
        var product = new Product(1, "Test", 10, Currency.USD, 10);

        // Assert
        Assert.AreEqual(1, product.Id);
        Assert.AreEqual("Test", product.Name);
        Assert.AreEqual(10, product.Price);
        Assert.AreEqual(Currency.USD, product.Currency);
        Assert.AreEqual(10, product.Quantity);
    }
}
