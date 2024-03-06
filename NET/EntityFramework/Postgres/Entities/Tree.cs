namespace EntityFramework.Postgres.Entities {
    using Microsoft.EntityFrameworkCore;

    public class Tree {
        public int Id { get; set; }
        public string? Code { get; set; }
        public LTree LTree { get; set; }
        public DateTime? Dt { get; set; }
    }
}
