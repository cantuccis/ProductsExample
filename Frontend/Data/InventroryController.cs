using Backend;

namespace Frontend.Data;

public class InventroyController
{

    public InventroyController()
    {
    
    }

    public void ReceiveProduct(ReceiveProductTransaction transaction, Warehouse warehouse)
    {   
        var inventoryManager = new InventoryManager(warehouse);
        inventoryManager.ReceiveProduct(transaction);
    }

}