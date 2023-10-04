using Backend.Auth;

namespace Backend
{
    public class Warehouse
    {
        public int Id { get; set; }

        private string name = string.Empty;
        private readonly List<Product> products = new();
        private readonly User owner;

        public Warehouse(int id, WarehouseData data, User owner)
        {
            Id = id;
            Name = data.Name;
            this.owner = owner;
        }

        public string Name
        {
            get => name;
            set
            {
                if (value == string.Empty)
                {
                    throw new ArgumentException("Name cannot be empty");
                }
                name = value;
            }
        }

        public IReadOnlyList<Product> Products => products; // Return a read-only list so that the list cannot be modified from outside the class

        public void StoreProduct(Product product)
        {
            if (product == null)
            {
                throw new ArgumentNullException(nameof(product));
            }

            if (products.Any(p => p.Name == product.Name))
            {
                throw new ArgumentException($"Product {product.Name} already exists");
            }

            product.Id = NextProductId;
            products.Add(product);
        }

        public void DeleteProduct(int id)
        {
            var product = products.FirstOrDefault(p => p.Id == id) ?? throw new ArgumentException("Product does not exist");
            products.Remove(product);
        }

        public Product GetProductById(int id)
        {
            return products.FirstOrDefault(p => p.Id == id) ?? throw new ArgumentException("Product does not exist");
        }

        public bool Allows(Credentials creds) => owner.AreCredentialsValid(creds);

        private int NextProductId => products.Count > 0 ? products.Max(p => p.Id) + 1 : 1;
    }
}