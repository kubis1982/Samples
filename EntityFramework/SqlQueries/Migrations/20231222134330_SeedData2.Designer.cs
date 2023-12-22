﻿// <auto-generated />
using EntityFramework.SqlQueries;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EntityFramework.SqlQueries.Migrations
{
    [DbContext(typeof(MyDbContext))]
    [Migration("20231222134330_SeedData2")]
    partial class SeedData2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.13");

            modelBuilder.Entity("EntityFramework.SqlQueries.Entities.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ContractorId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Order");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ContractorId = 1
                        },
                        new
                        {
                            Id = 2,
                            ContractorId = 2
                        },
                        new
                        {
                            Id = 3,
                            ContractorId = 3
                        },
                        new
                        {
                            Id = 4,
                            ContractorId = 4
                        });
                });

            modelBuilder.Entity("EntityFramework.SqlQueries.Entities.OrderItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ArticleId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("OrderId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.ToTable("OrderItem");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ArticleId = 1,
                            OrderId = 1
                        },
                        new
                        {
                            Id = 2,
                            ArticleId = 2,
                            OrderId = 1
                        },
                        new
                        {
                            Id = 3,
                            ArticleId = 3,
                            OrderId = 1
                        },
                        new
                        {
                            Id = 4,
                            ArticleId = 4,
                            OrderId = 1
                        },
                        new
                        {
                            Id = 5,
                            ArticleId = 1,
                            OrderId = 2
                        },
                        new
                        {
                            Id = 6,
                            ArticleId = 2,
                            OrderId = 2
                        },
                        new
                        {
                            Id = 7,
                            ArticleId = 3,
                            OrderId = 2
                        },
                        new
                        {
                            Id = 8,
                            ArticleId = 4,
                            OrderId = 2
                        },
                        new
                        {
                            Id = 9,
                            ArticleId = 1,
                            OrderId = 3
                        },
                        new
                        {
                            Id = 10,
                            ArticleId = 2,
                            OrderId = 3
                        },
                        new
                        {
                            Id = 11,
                            ArticleId = 3,
                            OrderId = 3
                        },
                        new
                        {
                            Id = 12,
                            ArticleId = 4,
                            OrderId = 3
                        },
                        new
                        {
                            Id = 13,
                            ArticleId = 1,
                            OrderId = 4
                        },
                        new
                        {
                            Id = 14,
                            ArticleId = 2,
                            OrderId = 4
                        },
                        new
                        {
                            Id = 15,
                            ArticleId = 3,
                            OrderId = 4
                        },
                        new
                        {
                            Id = 16,
                            ArticleId = 4,
                            OrderId = 4
                        });
                });

            modelBuilder.Entity("EntityFramework.SqlQueries.Entities.OrderItem", b =>
                {
                    b.HasOne("EntityFramework.SqlQueries.Entities.Order", "Order")
                        .WithMany("Items")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");
                });

            modelBuilder.Entity("EntityFramework.SqlQueries.Entities.Order", b =>
                {
                    b.Navigation("Items");
                });
#pragma warning restore 612, 618
        }
    }
}