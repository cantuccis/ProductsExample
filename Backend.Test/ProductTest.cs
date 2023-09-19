namespace Backend.Test;

[TestClass]
public class ProductTest
{
    [TestMethod]
    public void CreateNewProductTest()
    {
        // Arrange
        var product = new Product(1, "Test", 10, Currency.USD, 10);

        // Act
        var result = product;

        // Assert
        Assert.AreEqual(1, result.Id);
        Assert.AreEqual("Test", result.Name);
        Assert.AreEqual(10, result.Price);
        Assert.AreEqual(Currency.USD, result.Currency);
        Assert.AreEqual(10, result.Quantity);
    }
}