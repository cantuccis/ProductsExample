using Backend;

namespace Frontend.Data;

public class CurrentWarehouseController
{
    private Warehouse warehouse;

    public CurrentWarehouseController()
    {
        warehouse = new(1, new WarehouseData
        {
            Name = "Warehouse 1",
        });
    }

    public List<Product> Products => warehouse.Products.ToList();

    public void StoreProduct(Product product) => warehouse.StoreProduct(product);

    public void RemoveProduct(int id) => warehouse.DeleteProduct(id);

    public string WarehouseName => warehouse.Name;


}