﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using SecretService.Data;
using System;

namespace SecretService.Data.Migrations
{
    [DbContext(typeof(SecretServiceContext))]
    partial class SecretServiceContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.0-rtm-26452")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SecretService.Data.Geometry", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("IsDeleted");

                    b.HasKey("Id");

                    b.ToTable("Geometry");
                });

            modelBuilder.Entity("SecretService.Data.Route", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("ArrivalTime");

                    b.Property<bool>("IsDeleted");

                    b.Property<DateTime>("RequestDate");

                    b.Property<int?>("RequesterId");

                    b.Property<DateTime>("ValidUntil");

                    b.HasKey("Id");

                    b.HasIndex("RequesterId");

                    b.ToTable("Routes");
                });

            modelBuilder.Entity("SecretService.Data.Stop", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("GeometryId");

                    b.Property<bool>("IsDeleted");

                    b.Property<int?>("RouteId");

                    b.Property<int>("StopType");

                    b.HasKey("Id");

                    b.HasIndex("GeometryId");

                    b.HasIndex("RouteId");

                    b.ToTable("Stops");
                });

            modelBuilder.Entity("SecretService.Data.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("Surname")
                        .IsRequired();

                    b.Property<string>("UserName")
                        .IsRequired();

                    b.Property<int>("UserRole");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("SecretService.Data.Route", b =>
                {
                    b.HasOne("SecretService.Data.User", "Requester")
                        .WithMany("Routes")
                        .HasForeignKey("RequesterId");
                });

            modelBuilder.Entity("SecretService.Data.Stop", b =>
                {
                    b.HasOne("SecretService.Data.Geometry", "Geometry")
                        .WithMany()
                        .HasForeignKey("GeometryId");

                    b.HasOne("SecretService.Data.Route", "Route")
                        .WithMany("Stops")
                        .HasForeignKey("RouteId");
                });
#pragma warning restore 612, 618
        }
    }
}
