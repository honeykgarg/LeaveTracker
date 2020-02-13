﻿// <auto-generated />
using System;
using LeaveTracker.API.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LeaveTracker.API.Migrations
{
    [DbContext(typeof(LeaveTrackerDbContext))]
    [Migration("20200213175119_secondMigration")]
    partial class secondMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("LeaveTracker.API.Models.Employee", b =>
                {
                    b.Property<string>("EmpId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("EmailId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("EmpId");

                    b.ToTable("Employees");

                    b.HasData(
                        new
                        {
                            EmpId = "1801942",
                            EmailId = "hkumar25@dxc.com",
                            Name = "Honey Kumar"
                        },
                        new
                        {
                            EmpId = "1801943",
                            EmailId = "hkumar27@dxc.com",
                            Name = "Honey Garg"
                        });
                });

            modelBuilder.Entity("LeaveTracker.API.Models.Leave", b =>
                {
                    b.Property<Guid>("LeaveEntryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("EmpId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("LeaveEndDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("LeaveEntryAddedOrUpdatedTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("LeaveStartDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("LeaveEntryId");

                    b.HasIndex("EmpId");

                    b.ToTable("Leaves");

                    b.HasData(
                        new
                        {
                            LeaveEntryId = new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b35"),
                            EmpId = "1801942",
                            LeaveEndDate = new DateTime(2020, 2, 21, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LeaveEntryAddedOrUpdatedTime = new DateTime(2020, 2, 13, 23, 21, 18, 618, DateTimeKind.Local).AddTicks(6279),
                            LeaveStartDate = new DateTime(2020, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Status = "Pending"
                        });
                });

            modelBuilder.Entity("LeaveTracker.API.Models.Leave", b =>
                {
                    b.HasOne("LeaveTracker.API.Models.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("EmpId");
                });
#pragma warning restore 612, 618
        }
    }
}
