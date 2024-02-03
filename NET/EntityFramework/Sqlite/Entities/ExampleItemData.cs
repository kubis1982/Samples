namespace EntityFramework.Sqlite.Entities {
    public class ExampleItemData {
        public int Id { get; set; }
        public string? Name { get; set; }
        public required ExampleData ExampleData { get; set; }
    }
}
