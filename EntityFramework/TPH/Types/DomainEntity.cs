namespace EntityFramework.TPH.Types {
    using System;
    using System.Collections.Generic;

    public abstract class DomainEntity<TEntityId, TKey> where TEntityId : EntityId<TKey> {
        public TEntityId Id { get; protected set; } = null!;

        private protected DomainEntity() {
        }

        public override bool Equals(object? obj) {
            return Equals(obj as DomainEntity<TEntityId, TKey>);
        }

        public bool Equals(DomainEntity<TEntityId, TKey>? other) {
            return other is not null &&
                   EqualityComparer<TEntityId>.Default.Equals(Id, other.Id);
        }

        public override int GetHashCode() {
            return HashCode.Combine(Id);
        }

        public static bool operator ==(DomainEntity<TEntityId, TKey>? left, DomainEntity<TEntityId, TKey>? right) {
            return EqualityComparer<DomainEntity<TEntityId, TKey>>.Default.Equals(left, right);
        }

        public static bool operator !=(DomainEntity<TEntityId, TKey>? left, DomainEntity<TEntityId, TKey>? right) {
            return !(left == right);
        }
    }

    public abstract class DomainEntity<TEntityId, TKey, TEntityTypeEnumerator> : DomainEntity<TEntityId, TKey> where TEntityId : EntityId<TKey, TEntityTypeEnumerator> where TEntityTypeEnumerator : EntityTypeEnumerator {
    }
}
