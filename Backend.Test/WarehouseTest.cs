namespace Backend.Test;

[TestClass]
public class WarehouseTest
{
    [TestMethod]
    public void CreateNewWarehouseTest()
    {
        // Arrange
        var warehouseData = new WarehouseData
        {
            Name = "Test",
        };

        // Act
        var warehouse = new Warehouse(1, warehouseData);

        // Assert
        Assert.AreEqual(1, warehouse.Id);
        Assert.AreEqual(warehouseData.Name, warehouse.Name);
    }

    [TestMethod]
    public void CreateWarehouseWithEmptyNameShouldFailTest()
    {
        // Arrange
        var warehouseData = new WarehouseData
        {
            Name = string.Empty,
        };

        // Act
        var exception = Assert.ThrowsException<ArgumentException>(() => new Warehouse(1, warehouseData));

        // Assert
        Assert.AreEqual("Name cannot be empty", exception.Message);
    }

    [TestMethod]
    public void StoreProductTest() 
    {
        // Arrange
        var warehouseData = new WarehouseData
        {
            Name = "Test",
        };
        var warehouse = new Warehouse(1, warehouseData);
        var productData = new ProductData
        {
            Name = "Test",
            Price = 10,
            Currency = Currency.USD,
            Quantity = 10,
        };
        var product = new Product(1, productData);

        // Act
        warehouse.StoreProduct(product);

        // Assert
        Assert.AreEqual(1, warehouse.Products.Count);
        Assert.AreEqual(product, warehouse.Products[0]);
    }

    [TestMethod]
    public void DeleteProductFromWarehouseTest() 
    {
        // Arrange
        var warehouseData = new WarehouseData
        {
            Name = "Test",
        };
        var warehouse = new Warehouse(1, warehouseData);
        var productData = new ProductData
        {
            Name = "Test",
            Price = 10,
            Currency = Currency.USD,
            Quantity = 10,
        };
        var product = new Product(1, productData);
        warehouse.StoreProduct(product);

        // Act
        warehouse.DeleteProduct(product.Id);

        // Assert
        Assert.AreEqual(0, warehouse.Products.Count);
    }

    [TestMethod]
    public void DeleteProductFromWarehouseWithNonExistingProductShouldFailTest() 
    {
        // Arrange
        var warehouseData = new WarehouseData
        {
            Name = "Test",
        };
        var warehouse = new Warehouse(1, warehouseData);

        // Act
        var exception = Assert.ThrowsException<ArgumentException>(() => warehouse.DeleteProduct(1));

        // Assert
        Assert.AreEqual("Product does not exist", exception.Message);
    }

    [TestMethod]
    public void StoreAlreadyExistingProductShouldFailTest() 
    {
        // Arrange
        var warehouseData = new WarehouseData
        {
            Name = "Test",
        };
        var warehouse = new Warehouse(1, warehouseData);
        var productData = new ProductData
        {
            Name = "Test",
            Price = 10,
            Currency = Currency.USD,
            Quantity = 10,
        };
        var product = new Product(1, productData);
        warehouse.StoreProduct(product);

        // Act
        var exception = Assert.ThrowsException<ArgumentException>(() => warehouse.StoreProduct(product));

        // Assert
        Assert.AreEqual("Product Test already exists", exception.Message);
    }

  

    [TestMethod]
    public void GetProductsTest() 
    {
        // Arrange
        var warehouseData = new WarehouseData
        {
            Name = "Test",
        };
        var warehouse = new Warehouse(1, warehouseData);
        var productData1 = new ProductData
        {
            Name = "Test1",
            Price = 10,
            Currency = Currency.USD,
            Quantity = 10,
        };
        var product1 = new Product(0, productData1);
        var productData2 = new ProductData
        {
            Name = "Test2",
            Price = 20,
            Currency = Currency.USD,
            Quantity = 20,
        };
        var product2 = new Product(0, productData2);
        warehouse.StoreProduct(product1);
        warehouse.StoreProduct(product2);

        // Act
        var products = warehouse.Products;

        // Assert
        Assert.AreEqual(2, products.Count);
        Assert.AreEqual(product1, products[0]);
        Assert.AreEqual(product2, products[1]);
    }

    [TestMethod]
    public void GetProductByIdTest() 
    {
        // Arrange
        var warehouseData = new WarehouseData
        {
            Name = "Test",
        };
        var warehouse = new Warehouse(1, warehouseData);
        var productData1 = new ProductData
        {
            Name = "Test1",
            Price = 10,
            Currency = Currency.USD,
            Quantity = 10,
        };
        var product1 = new Product(0, productData1);
        var productData2 = new ProductData
        {
            Name = "Test2",
            Price = 20,
            Currency = Currency.USD,
            Quantity = 20,
        };
        var product2 = new Product(0, productData2);
        warehouse.StoreProduct(product1);
        warehouse.StoreProduct(product2);

        // Act
        var product = warehouse.GetProductById(product1.Id);

        // Assert
        Assert.AreEqual(product1, product);
    }

    [TestMethod]
    public void GetProductByIdWithNonExistingProductShouldFailTest() 
    {
        // Arrange
        var warehouseData = new WarehouseData
        {
            Name = "Test",
        };
        var warehouse = new Warehouse(1, warehouseData);

        // Act
        var exception = Assert.ThrowsException<ArgumentException>(() => warehouse.GetProductById(1));

        // Assert
        Assert.AreEqual("Product does not exist", exception.Message);
    }
    
}