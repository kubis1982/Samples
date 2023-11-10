namespace EntityFramework.TPH {
    using EntityFramework.TPH.Types;

    public abstract record EntityId : EntityId<int, EntityType> {
        protected EntityId(EntityType entityType, int id) : base(entityType, id) {
        }
    }
}
