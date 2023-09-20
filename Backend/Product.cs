namespace Backend
{
    public class Product
    {
        private double price;
        private int quantity;

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
        
        public int Quantity
        {
            get => quantity; private set
            {

                if (value < 0)
                {
                    throw new ArgumentException("Quantity cannot be negative");
                }
                quantity = value;
            }
        }

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