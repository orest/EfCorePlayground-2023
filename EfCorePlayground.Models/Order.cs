namespace EfCorePlayground.Models {
    public class Order {
        public Order() {
            OrderItems = new List<OrderItem>();
        }
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public decimal OrderTotal { get; set; }
        public decimal? DiscountAmount { get; set; }
        public DateTime CreatedOn { get; set; }
        public bool IsComplete { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }
        public Customer Customer { get; set; }
    }
}
