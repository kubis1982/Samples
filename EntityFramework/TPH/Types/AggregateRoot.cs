namespace EntityFramework.TPH.Types {
    public abstract class AggregateRoot<TEntityId, TKey> : DomainEntity<TEntityId, TKey>, IAggregateRoot where TEntityId : EntityId<TKey> {
        protected AggregateRoot() {
        }
    }

    public abstract class AggregateRoot<TEntityId, TKey, TEntityTypeEnumerator> : DomainEntity<TEntityId, TKey, TEntityTypeEnumerator>, IAggregateRoot where TEntityId : EntityId<TKey, TEntityTypeEnumerator> where TEntityTypeEnumerator : EntityTypeEnumerator {
        protected AggregateRoot() {
        }
    }
}
