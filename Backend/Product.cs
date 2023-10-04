namespace Backend
{
    public class Product
    {
        private double price;
        private int quantity;
        private string name = string.Empty;

        public int Id { get; set; }
        public string Name
        {
            get => name;
            private set
            {
                if (value == string.Empty)
                {
                    throw new ArgumentException("Name cannot be empty");
                }

                name = value;
            }
        }
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
        public Currency Currency { get; private set; } = Currency.USD;

        public int Quantity
        {
            get => quantity;  set
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