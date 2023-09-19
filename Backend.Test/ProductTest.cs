using Backend;

namespace Backend.Test;

[TestClass]
public class ProductTest
{
    [TestMethod]
    public void CreateNewProductTest()
    {
        // Arrange
        var productData = new ProductData
        {
            Name = "Test",
            Price = 10,
            Currency = Currency.USD,
            Quantity = 10,
        };

        // Act
        var product = new Product(1, productData);

        // Assert
        Assert.AreEqual(1, product.Id);
        Assert.AreEqual(productData.Name, product.Name);
        Assert.AreEqual(productData.Price, product.Price);
        Assert.AreEqual(productData.Currency, product.Currency);
        Assert.AreEqual(productData.Quantity, product.Quantity);
    }

}
