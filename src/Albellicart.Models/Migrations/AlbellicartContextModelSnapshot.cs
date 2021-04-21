﻿// <auto-generated />
using System;
using System.Diagnostics.CodeAnalysis;
using Albellicart.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Albellicart.Models.Migrations
{
    [ExcludeFromCodeCoverage]
    [DbContext(typeof(AlbellicartContext))]
    partial class AlbellicartContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.5");

            modelBuilder.Entity("Albellicart.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<double>("RequiredBinWidth")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("Albellicart.Models.OrderLine", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("OrderId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ProductType")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Quantity")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.ToTable("OrderLine");
                });

            modelBuilder.Entity("Albellicart.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ProductType")
                        .HasColumnType("INTEGER");

                    b.Property<int>("WidthFactor")
                        .HasColumnType("INTEGER");

                    b.Property<double>("WidthInmm")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("Albellicart.Models.OrderLine", b =>
                {
                    b.HasOne("Albellicart.Models.Order", "Order")
                        .WithMany("OrderLine")
                        .HasForeignKey("OrderId");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("Albellicart.Models.Order", b =>
                {
                    b.Navigation("OrderLine");
                });
#pragma warning restore 612, 618
        }
    }
}
