namespace EfCorePlayground.Models {
    public class OrderItem {
        public int OrderItemId { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public decimal Quantity { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedByUserId { get; set; }
        public Order Order { get; set; }
        public Product Product { get; set; }
    }
}
