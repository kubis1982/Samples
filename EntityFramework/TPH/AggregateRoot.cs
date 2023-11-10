namespace EntityFramework.TPH {
    using EntityFramework.TPH.Types;

    public abstract class AggregateRoot<TEntity> : AggregateRoot<TEntity, int, EntityType>
        where TEntity : EntityId {
    }
}
