namespace EntityFramework.TPH {
    using EntityFramework.TPH.Types;

    public class EntityType : EntityTypeEnumerator {
        public const string Prefix = "OrM";

        private EntityType(short numerator, string name) : base(Prefix, numerator, name) {
        }

        public static EntityType SaleOrder => new(1, "Zamówienie sprzedaży");
        public static EntityType PurchaseOrder => new(2, "Zamówienie zakupu");
    }
}