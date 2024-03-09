namespace EntityFramework.Postgres.Entities {
    public class Collection {
        public int Id { get; set; }
        public string[] Tags { get; set; } = [];
    }
}
