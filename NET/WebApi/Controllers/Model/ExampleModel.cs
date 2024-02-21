namespace OData.Controllers.Model {
    public class ExampleModel {
        public int Id { get; set; }
        public string? Name { get; set; }
        public ExampleItemModel[] Items { get; set; } = [];
    }
}
