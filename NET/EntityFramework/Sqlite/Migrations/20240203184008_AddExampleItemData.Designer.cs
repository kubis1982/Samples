﻿// <auto-generated />
using EntityFramework.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EntityFramework.Sqlite.Migrations
{
    [DbContext(typeof(SqliteDbContext))]
    [Migration("20240203184008_AddExampleItemData")]
    partial class AddExampleItemData
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.1");

            modelBuilder.Entity("EntityFramework.Sqlite.Entities.ExampleData", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasMaxLength(80)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("ExampleDatas");
                });

            modelBuilder.Entity("EntityFramework.Sqlite.Entities.ExampleItemData", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ExampleId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasMaxLength(80)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ExampleId");

                    b.ToTable("ExampleItemData");
                });

            modelBuilder.Entity("EntityFramework.Sqlite.Entities.ExampleItemData", b =>
                {
                    b.HasOne("EntityFramework.Sqlite.Entities.ExampleData", "ExampleData")
                        .WithMany("Items")
                        .HasForeignKey("ExampleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ExampleData");
                });

            modelBuilder.Entity("EntityFramework.Sqlite.Entities.ExampleData", b =>
                {
                    b.Navigation("Items");
                });
#pragma warning restore 612, 618
        }
    }
}
