namespace EntityFramework.TPH.Types {
    public record EntityId<TKey, TEntityTypeEnumerator> : EntityId<TKey> where TEntityTypeEnumerator : EntityTypeEnumerator {
        public EntityId(TEntityTypeEnumerator entityTypeEnumerator, TKey id) : base(id) {
            TypeId = entityTypeEnumerator.Code;
        }

        public EntityTypeId TypeId { get; }
    }

    public record EntityId<TKey>(TKey Value);
}
