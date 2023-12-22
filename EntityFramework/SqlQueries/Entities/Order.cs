namespace EntityFramework.SqlQueries.Entities {
    public class Order {
        public int Id { get; set; }

        public ICollection<OrderItem> Items { get; set; } = null!;

        public int ContractorId { get; set; }
    }
}
