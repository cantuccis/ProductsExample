using Backend;
using Backend.Auth;

namespace Frontend.Data;

public class InventroyController
{
    private readonly AuthController _authController;
    public InventroyController(AuthController authController)
    {
        _authController = authController;
    }

    public void ReceiveProduct(ReceiveProductTransaction transaction, Warehouse warehouse)
    {   
        var inventoryManager = new InventoryManager(warehouse);
        inventoryManager.ReceiveProduct(_authController.CurrentUserCredentials, transaction);
    }

    public void ShipProduct(ShipProductTransaction transaction, Warehouse warehouse)
    {
        var inventoryManager = new InventoryManager(warehouse);
        inventoryManager.ShipProduct(_authController.CurrentUserCredentials, transaction);
    }

}