namespace EntityFramework.TPH.Entities {
    public class PurchaseOrder : Order<PurchaseOrderId> {
    }

    public record PurchaseOrderId : OrderId {
        public PurchaseOrderId(int id) : base(EntityType.PurchaseOrder, id) {
        }
    }
}
