namespace EntityFramework.TPH.Entities {
    public class SaleOrder : Order<SaleOrderId> {
    }

    public record SaleOrderId : OrderId {
        public SaleOrderId(int id) : base(EntityType.PurchaseOrder, id) {
        }
    }
}
