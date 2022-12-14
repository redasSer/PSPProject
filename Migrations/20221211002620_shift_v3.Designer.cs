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
    [Migration("20221211002620_shift_v3")]
    partial class shiftv3
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

            modelBuilder.Entity("PSP.Models.Shift", b =>
                {
                    b.Property<Guid>("ShiftId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

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
