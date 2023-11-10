namespace EntityFramework.TPH.Entities {
    public abstract class Order<TEntity> : AggregateRoot<TEntity> where TEntity : OrderId {
       // private readonly List<OrderItem> items = new();

        protected Order() {
        }

        //public IEnumerable<OrderItem> Items => items;
    }

    public abstract record OrderId : EntityId {
        protected OrderId(EntityType entityType, int id) : base(entityType, id) {
        }
    }
}
