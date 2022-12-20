﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PSP.Data;

#nullable disable

namespace PSP.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20221215175328_Modifiers")]
    partial class Modifiers
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.0");

            modelBuilder.Entity("PSP.Models.Booking", b =>
                {
                    b.Property<Guid>("bookingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("description")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("orderId")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("time")
                        .HasColumnType("TEXT");

                    b.HasKey("bookingId");

                    b.ToTable("Booking");
                });

            modelBuilder.Entity("PSP.Models.CatalogueItem", b =>
                {
                    b.Property<Guid>("CatalogueItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Category")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("ClientId")
                        .HasColumnType("TEXT");

                    b.Property<int>("LoyaltyPointsReward")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<double>("Price")
                        .HasColumnType("REAL");

                    b.Property<int>("Tax")
                        .HasColumnType("INTEGER");

                    b.HasKey("CatalogueItemId");

                    b.ToTable("CatalogueItem");
                });

            modelBuilder.Entity("PSP.Models.Employee", b =>
                {
                    b.Property<Guid>("EmployeeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("LocationId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("TEXT");

                    b.Property<int>("Status")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Username")
                        .HasColumnType("TEXT");

                    b.HasKey("EmployeeId");

                    b.ToTable("Employee");
                });

            modelBuilder.Entity("PSP.Models.EmployeeCard", b =>
                {
                    b.Property<Guid>("EmployeeCardId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("EmployeeId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("LocationId")
                        .HasColumnType("TEXT");

                    b.Property<int>("Status")
                        .HasColumnType("INTEGER");

                    b.HasKey("EmployeeCardId");

                    b.ToTable("EmployeeCard");
                });

            modelBuilder.Entity("PSP.Models.Inventory", b =>
                {
                    b.Property<Guid>("ItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<int>("Amount")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Item")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("LocationId")
                        .HasColumnType("TEXT");

                    b.HasKey("ItemId");

                    b.ToTable("Inventory");
                });

            modelBuilder.Entity("PSP.Models.InventoryUsage", b =>
                {
                    b.Property<Guid>("InventoryUsageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<int>("Amount")
                        .HasColumnType("INTEGER");

                    b.Property<Guid>("CatalogueItemId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("ClientId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("ItemId")
                        .HasColumnType("TEXT");

                    b.HasKey("InventoryUsageId");

                    b.ToTable("InventoryUsage");
                });

            modelBuilder.Entity("PSP.Models.Modifier", b =>
                {
                    b.Property<Guid>("ModifierId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<int>("Amount")
                        .HasColumnType("INTEGER");

                    b.Property<Guid>("CatalogueItemId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("ClientId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("ItemId")
                        .HasColumnType("TEXT");

                    b.Property<int>("LoyaltyPointsModifier")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PriceModifier")
                        .HasColumnType("INTEGER");

                    b.HasKey("ModifierId");

                    b.ToTable("Modifier");
                });

            modelBuilder.Entity("PSP.Models.Permission", b =>
                {
                    b.Property<Guid>("PermissionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("ClientId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("PermissionTypeId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("TEXT");

                    b.HasKey("PermissionId");

                    b.ToTable("Permission");
                });

            modelBuilder.Entity("PSP.Models.PermissionType", b =>
                {
                    b.Property<Guid>("PermissionTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("PermissionTypeId");

                    b.ToTable("PermissionType");
                });

            modelBuilder.Entity("PSP.Models.Role", b =>
                {
                    b.Property<Guid>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("ClientId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .HasColumnType("TEXT");

                    b.HasKey("RoleId");

                    b.ToTable("Role");
                });

            modelBuilder.Entity("PSP.Models.Shift", b =>
                {
                    b.Property<Guid>("ShiftId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<TimeSpan>("EndTimeTS")
                        .HasColumnType("TEXT")
                        .HasColumnName("EndTime");

                    b.Property<TimeSpan>("StartTimeTS")
                        .HasColumnType("TEXT")
                        .HasColumnName("StartTime");

                    b.HasKey("ShiftId");

                    b.ToTable("Shift");
                });

            modelBuilder.Entity("PSP.entity.EmployeeShift", b =>
                {
                    b.Property<Guid>("EmployeeShiftsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("EmployeeId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ShiftId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("WorkDay")
                        .HasColumnType("TEXT");

                    b.HasKey("EmployeeShiftsId");

                    b.ToTable("EmployeeShift");
                });
#pragma warning restore 612, 618
        }
    }
}
