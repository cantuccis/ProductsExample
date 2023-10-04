namespace Backend
{
    public class InventoryManager
    {
        private readonly Warehouse warehouse;

        private readonly List<ReceiveProductTransaction> receiveTransactions = new();
        private readonly List<ShipProductTransaction> shippedTransactions = new();


        public InventoryManager(Warehouse warehouse)
        {
            this.warehouse = warehouse ?? throw new ArgumentNullException(nameof(warehouse));
        }


        public void  ReceiveProduct(ReceiveProductTransaction transaction)
        {
            var product = warehouse.GetProductById(transaction.ProductId);
            product.ProcessReceiveTransaction(transaction);
            receiveTransactions.Add(transaction);
        }

        public void ShipProduct(ShipProductTransaction transaction)
        {
            var product = warehouse.GetProductById(transaction.ProductId);
            product.ProcessShipTransaction(transaction);
            shippedTransactions.Add(transaction);
        }
    }
}