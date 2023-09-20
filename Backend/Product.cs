namespace Backend
{
    public class Product
    {
        private double price;

        public int Id { get; private set; }
        public string Name { get; private set; }
        public double Price
        {
            get => price;

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Price cannot be negative");
                }
                
                price = value;
            }
        }
        public Currency Currency { get; private set; }
        public int Quantity { get; private set; }

        public Product(int id, ProductData data)
        {
            Id = id;
            Name = data.Name;
            Price = data.Price;
            Currency = data.Currency;
            Quantity = data.Quantity;
        }

    }
}