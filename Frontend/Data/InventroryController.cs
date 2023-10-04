using Backend;
using Backend.Auth;

namespace Frontend.Data;

public class InventroyController
{
    private readonly Credentials credentials;

    public InventroyController(Credentials creds)
    {
        credentials = creds;
    }

    public void ReceiveProduct(ReceiveProductTransaction transaction, Warehouse warehouse)
    {   
        var inventoryManager = new InventoryManager(warehouse);
        inventoryManager.ReceiveProduct(credentials, transaction);
    }

    public void ShipProduct(ShipProductTransaction transaction, Warehouse warehouse)
    {
        var inventoryManager = new InventoryManager(warehouse);
        inventoryManager.ShipProduct(credentials, transaction);
    }

}