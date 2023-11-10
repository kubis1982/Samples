namespace EntityFramework.TPH {
    using EntityFramework.TPH.Types;

    public abstract class DomainEntity<TEntity> : DomainEntity<TEntity, int, EntityType>
        where TEntity : EntityId {
    }
}
