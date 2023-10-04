using Backend.Auth;

namespace Backend.Test;

[TestClass]
public class InventoryManagerTest
{

    private Warehouse warehouse;
    private AuthManager authManager;
    private Credentials creds;

    [TestInitialize]
    public void SetUp()
    {
        warehouse = new(1, new WarehouseData
        {
            Name = "Test",
        },
        new("owner", "owner"));
        authManager = new AuthManager();
        authManager.SignUp("owner", "owner");
        creds = authManager.SignIn("owner", "owner");
    }

    [TestMethod]
    public void CreateNewInventoryManagerTest()
    {
        // Act
        var inventoryManager = new InventoryManager(warehouse);

        // Assert
        Assert.IsNotNull(inventoryManager);
    }

    [TestMethod]
    public void CreateInventoryManagerWithNullWarehouseShouldFailTest()
    {
        // Act
        var exception = Assert.ThrowsException<ArgumentNullException>(() => new InventoryManager(warehouse: null));

        // Assert
        Assert.AreEqual("Value cannot be null. (Parameter 'warehouse')", exception.Message);
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
        warehouse.StoreProduct(product);
        var transaction = new ReceiveProductTransaction() with
        {
            ProductId = 1,
            Quantity = 10,
        };

        // Act
        inventoryManager.ReceiveProduct(creds, transaction);

        // Assert
        Assert.AreEqual(20, warehouse.Products[0].Quantity);
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
        var exception = Assert.ThrowsException<ArgumentException>(() => inventoryManager.ReceiveProduct(creds, transaction));

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
        warehouse.StoreProduct(product);
        var transaction = new ReceiveProductTransaction
        {
            ProductId = 1,
            Quantity = -10,
        };

        // Act
        var exception = Assert.ThrowsException<ArgumentException>(() => inventoryManager.ReceiveProduct(creds, transaction));

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
        warehouse.StoreProduct(product);
        var transaction = new ShipProductTransaction
        {
            ProductId = 1,
            Quantity = 10,
        };

        // Act
        inventoryManager.ShipProduct(creds, transaction);

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
        var exception = Assert.ThrowsException<ArgumentException>(() => inventoryManager.ShipProduct(creds, transaction));

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
        warehouse.StoreProduct(product);
        var transaction = new ShipProductTransaction
        {
            ProductId = 1,
            Quantity = -10,
        };

        // Act
        var exception = Assert.ThrowsException<ArgumentException>(() => inventoryManager.ShipProduct(creds, transaction));

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
        var product = new Product(0, productData);
        warehouse.StoreProduct(product);
        var transaction = new ShipProductTransaction
        {
            ProductId = 1,
            Quantity = 20,
        };

        // Act
        var exception = Assert.ThrowsException<ArgumentException>(() => inventoryManager.ShipProduct(creds, transaction));

        // Assert
        Assert.AreEqual("Quantity must be less than or equal to the quantity in the warehouse", exception.Message);
    }

}