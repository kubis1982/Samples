﻿namespace EntityFramework.TPH.Configurations.Converters {
    using EntityFramework.TPH.Types;
    using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

    internal class EntityTypeIdConverter : ValueConverter<EntityTypeId, string> {
        public EntityTypeIdConverter() : base(
               code => code.Value,
               code => string.IsNullOrEmpty(code) ? EntityTypeId.Empty : new EntityTypeId(code)) {
        }
    }
}
