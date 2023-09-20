namespace Backend.Test;

[TestClass]
public class InventoryManagerTest
{
    private Warehouse warehouse = new(1, new WarehouseData
    {
        Name = "Test",
    });

    [TestInitialize]
    public void SetUp()
    {
        warehouse = new(1, new WarehouseData
        {
            Name = "Test",
        });
    }

    [TestMethod]
    public void CreateNewInventoryManagerTest()
    {
        // Act
        var inventoryManager = new InventoryManager(warehouse);

        // Assert
        Assert.AreEqual(warehouse, inventoryManager.Warehouse);
    }

    [TestMethod]
    public void CreateInventoryManagerWithNullWarehouseShouldFailTest()
    {
        // Act
        var exception = Assert.ThrowsException<ArgumentNullException>(() => new InventoryManager(null));

        // Assert
        Assert.AreEqual("Value cannot be null. (Parameter 'warehouse')", exception.Message);
    }

    [TestMethod]
    public void AddProductTest()
    {
        // Arrange
        var inventoryManager = new InventoryManager(warehouse);
        var productData = new ProductData
        {
            Name = "Test",
            Price = 10,
            Currency = Currency.USD,
            Quantity = 10,
        };
        var product = new Product(1, productData);

        // Act
        inventoryManager.AddProduct(product);

        // Assert
        Assert.AreEqual(1, inventoryManager.Products.Count);
        Assert.AreEqual(product, inventoryManager.Products[0]);
    }

    [TestMethod]
    public void ReceiveProductTransactionTest()
    {
        // Arrange
        var inventoryManager = new InventoryManager(warehouse);
        var productData = new ProductData
        {
            Name = "Test",
            Price = 10,
            Currency = Currency.USD,
            Quantity = 10,
        };
        var product = new Product(1, productData);
        inventoryManager.AddProduct(product);
        var transaction = new ReceiveProductTransaction
        {
            ProductId = 1,
            Quantity = 10,
        };

        // Act
        inventoryManager.ReceiveProducts(transaction);

        // Assert
        Assert.AreEqual(20, inventoryManager.Products[0].Quantity);
    }

    [TestMethod]
    public void ReceiveProductTransactionWithInvalidProductIdShouldFailTest()
    {
        // Arrange
        var inventoryManager = new InventoryManager(warehouse);
        var transaction = new ReceiveProductTransaction
        {
            ProductId = 1,
            Quantity = 10,
        };

        // Act
        var exception = Assert.ThrowsException<ArgumentException>(() => inventoryManager.ReceiveProducts(transaction));

        // Assert
        Assert.AreEqual("Product does not exist", exception.Message);
    }

    [TestMethod]
    public void ReceiveProductTransactionWithNegativeQuantityShouldFailTest()
    {
        // Arrange
        var inventoryManager = new InventoryManager(warehouse);
        var productData = new ProductData
        {
            Name = "Test",
            Price = 10,
            Currency = Currency.USD,
            Quantity = 10,
        };
        var product = new Product(1, productData);
        inventoryManager.AddProduct(product);
        var transaction = new ReceiveProductTransaction
        {
            ProductId = 1,
            Quantity = -10,
        };

        // Act
        var exception = Assert.ThrowsException<ArgumentException>(() => inventoryManager.ReceiveProducts(transaction));

        // Assert
        Assert.AreEqual("Quantity cannot be negative", exception.Message);
    }

    [TestMethod]
    public void ShipProductTransactionTest()
    {
        // Arrange
        var inventoryManager = new InventoryManager(warehouse);
        var productData = new ProductData
        {
            Name = "Test",
            Price = 10,
            Currency = Currency.USD,
            Quantity = 10,
        };
        var product = new Product(1, productData);
        inventoryManager.AddProduct(product);
        var transaction = new ShipProductTransaction
        {
            ProductId = 1,
            Quantity = 10,
        };

        // Act
        inventoryManager.ShipProducts(transaction);

        // Assert
        Assert.AreEqual(0, warehouse.Products[0].Quantity);
    }

    [TestMethod]
    public void ShipProductTransactionWithInvalidProductIdShouldFailTest()
    {
        // Arrange
        var inventoryManager = new InventoryManager(warehouse);
        var transaction = new ShipProductTransaction
        {
            ProductId = 1,
            Quantity = 10,
        };

        // Act
        var exception = Assert.ThrowsException<ArgumentException>(() => inventoryManager.ShipProducts(transaction));

        // Assert
        Assert.AreEqual("Product does not exist", exception.Message);
    }

    [TestMethod]
    public void ShipProductTransactionWithNegativeQuantityShouldFailTest()
    {
        // Arrange
        var inventoryManager = new InventoryManager(warehouse);
        var productData = new ProductData
        {
            Name = "Test",
            Price = 10,
            Currency = Currency.USD,
            Quantity = 10,
        };
        var product = new Product(1, productData);
        inventoryManager.AddProduct(product);
        var transaction = new ShipProductTransaction
        {
            ProductId = 1,
            Quantity = -10,
        };

        // Act
        var exception = Assert.ThrowsException<ArgumentException>(() => inventoryManager.ShipProducts(transaction));

        // Assert
        Assert.AreEqual("Quantity cannot be negative", exception.Message);
    }

    [TestMethod]
    public void ShipProductTransactionWithInsufficientQuantityShouldFailTest()
    {
        // Arrange
        var inventoryManager = new InventoryManager(warehouse);
        var productData = new ProductData
        {
            Name = "Test",
            Price = 10,
            Currency = Currency.USD,
            Quantity = 10,
        };
        var product = new Product(1, productData);
        inventoryManager.AddProduct(product);
        var transaction = new ShipProductTransaction
        {
            ProductId = 1,
            Quantity = 20,
        };

        // Act
        var exception = Assert.ThrowsException<ArgumentException>(() => inventoryManager.ShipProducts(transaction));

        // Assert
        Assert.AreEqual("Insufficient quantity", exception.Message);
    }

}