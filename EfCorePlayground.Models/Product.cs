namespace EfCorePlayground.Models {
    public class Product {
        public Product() {
            OrderItems = new List<OrderItem>();
        }
        public int ProductId { get; set; }
        public string SKU { get; set; }
        public decimal Price { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }

    }
}
