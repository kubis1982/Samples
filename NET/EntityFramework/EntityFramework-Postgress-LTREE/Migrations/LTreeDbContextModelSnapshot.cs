﻿// <auto-generated />
using EntityFramework_Postgress_LTREE;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace EntityFramework_Postgress_LTREE.Migrations
{
    [DbContext(typeof(LTreeDbContext))]
    partial class LTreeDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.HasPostgresExtension(modelBuilder, "ltree");
            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("EntityFramework_Postgress_LTREE.LTreeModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Code")
                        .HasMaxLength(40)
                        .HasColumnType("character varying(40)");

                    b.Property<string>("LTree")
                        .IsRequired()
                        .HasColumnType("ltree");

                    b.Property<LTree>("Node")
                        .HasColumnType("ltree");

                    b.HasKey("Id");

                    b.ToTable("LTreeModels");
                });
#pragma warning restore 612, 618
        }
    }
}
