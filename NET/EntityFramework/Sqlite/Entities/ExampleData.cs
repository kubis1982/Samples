﻿namespace EntityFramework.Sqlite.Entities {
    public class ExampleData {
        public int Id { get; set; }
        public string? Name { get; set; }
        public ICollection<ExampleItemData> Items { get; set; } = new HashSet<ExampleItemData>();
    }
}
