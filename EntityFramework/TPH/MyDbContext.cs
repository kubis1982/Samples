﻿namespace EntityFramework.TPH {
    using EntityFramework.TPH.Configurations.Converters;
    using EntityFramework.TPH.Types;
    using Microsoft.EntityFrameworkCore;

    public class MyDbContext : DbContext {
        public MyDbContext(DbContextOptions options) : base(options) {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MyDbContext).Assembly);
        }

        protected sealed override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder) {
            base.ConfigureConventions(configurationBuilder);

            configurationBuilder
                .Properties<EntityTypeId>()
                .HaveMaxLength(5).AreFixedLength(true).AreUnicode(false)
                .HaveConversion<EntityTypeIdConverter>();

            configurationBuilder
                .Properties<DateTime>()
                .HavePrecision(2);

            configurationBuilder
                .Properties<decimal>()
                .HavePrecision(14, 4);

            configurationBuilder
               .Properties<string>()
               .HaveMaxLength(50);
        }
    }
}
