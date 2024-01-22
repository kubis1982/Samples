namespace EntityFramework_Postgress_LTREE {
    using Microsoft.EntityFrameworkCore;

    internal class LTreeModel {       
        public int Id { get; set; }
        public string? Code { get; set; }
        public LTree LTree { get; set; }
    }
}
