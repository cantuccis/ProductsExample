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
            if(transaction.Quantity < 0)
            {
                throw new ArgumentException("Quantity cannot be negative");
            }

            var product = warehouse.GetProductById(transaction.ProductId);
            product.Quantity += transaction.Quantity;
            receiveTransactions.Add(transaction);
        }

        public void ShipProduct(ShipProductTransaction transaction)
        {
            if(transaction.Quantity < 0)
            {
                throw new ArgumentException("Quantity cannot be negative");
            }

            var product = warehouse.GetProductById(transaction.ProductId);

            if(product.Quantity < transaction.Quantity)
            {
                throw new ArgumentException("Quantity must be less than or equal to the quantity in the warehouse");
            }
            product.Quantity -= transaction.Quantity;
        }
    }
}