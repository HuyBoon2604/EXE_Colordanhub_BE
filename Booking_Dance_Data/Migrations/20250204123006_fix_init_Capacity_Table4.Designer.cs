﻿// <auto-generated />
using System;
using Booking_Dance_Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Booking_Dance_Data.Migrations
{
    [DbContext(typeof(BookingDanceContext))]
    [Migration("20250204123006_fix_init_Capacity_Table4")]
    partial class fix_init_Capacity_Table4
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Booking_Dance_Data.Models.Entities.Account", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime?>("CreateAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("DateOfBirth")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DeleteAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GoogleId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime?>("UpdateAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("Booking_Dance_Data.Models.Entities.Booking", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("AccountId")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("BookingDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CheckIn")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CheckOut")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClassId")
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime?>("CreateAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeleteAt")
                        .HasColumnType("datetime2");

                    b.Property<bool?>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("StudioId")
                        .HasColumnType("nvarchar(50)");

                    b.Property<decimal>("TotalPrice")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime?>("UpdateAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.HasIndex("ClassId");

                    b.HasIndex("StudioId");

                    b.ToTable("Bookings");
                });

            modelBuilder.Entity("Booking_Dance_Data.Models.Entities.Capacity", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime?>("CreateAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeleteAt")
                        .HasColumnType("datetime2");

                    b.Property<bool?>("IsActive")
                        .HasColumnType("bit");

                    b.Property<int?>("Quantity")
                        .HasColumnType("int");

                    b.Property<string>("SizeId")
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("StudioId")
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime?>("UpdateAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("SizeId");

                    b.HasIndex("StudioId");

                    b.ToTable("Capacities");
                });

            modelBuilder.Entity("Booking_Dance_Data.Models.Entities.Category", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("CategoryDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreateAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeleteAt")
                        .HasColumnType("datetime2");

                    b.Property<bool?>("IsActive")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("UpdateAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Booking_Dance_Data.Models.Entities.ClassDance", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("AccountId")
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("ClassName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DateEnd")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DateOfWeek")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DateStart")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("Pricing")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("StudioId")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("TimeEnd")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TimeStart")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.HasIndex("StudioId");

                    b.ToTable("ClassDances");
                });

            modelBuilder.Entity("Booking_Dance_Data.Models.Entities.History", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime?>("CreateAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Datetime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Day")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DeleteAt")
                        .HasColumnType("datetime2");

                    b.Property<bool?>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("PaymentId")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<decimal>("Pricing")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime?>("UpdateAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("PaymentId");

                    b.ToTable("Histories");
                });

            modelBuilder.Entity("Booking_Dance_Data.Models.Entities.Image", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime?>("CreateAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeleteAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("ImageUrl1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl3")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl4")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl5")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("StudioId")
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime?>("UpdateAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("StudioId");

                    b.ToTable("Images");
                });

            modelBuilder.Entity("Booking_Dance_Data.Models.Entities.Noti", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("AccountId")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime?>("CreateAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeleteAt")
                        .HasColumnType("datetime2");

                    b.Property<bool?>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("NotiDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdateAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.ToTable("Notis");
                });

            modelBuilder.Entity("Booking_Dance_Data.Models.Entities.Order", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("BookingId")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime?>("CreateAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeleteAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("IsActive")
                        .HasColumnType("bit");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("UpdateAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("BookingId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Booking_Dance_Data.Models.Entities.Payment", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime?>("CreateAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeleteAt")
                        .HasColumnType("datetime2");

                    b.Property<bool?>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("OrderId")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("TransDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("TransactionCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdateAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.ToTable("Payments");
                });

            modelBuilder.Entity("Booking_Dance_Data.Models.Entities.Review", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("AccountId")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime?>("CreateAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeleteAt")
                        .HasColumnType("datetime2");

                    b.Property<bool?>("IsActive")
                        .HasColumnType("bit");

                    b.Property<float?>("Rating")
                        .HasColumnType("real");

                    b.Property<DateTime?>("ReviewDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ReviewMessage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StudioId")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime?>("UpdateAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.HasIndex("StudioId");

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("Booking_Dance_Data.Models.Entities.Role", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime?>("CreateAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeleteAt")
                        .HasColumnType("datetime2");

                    b.Property<bool?>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdateAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("Booking_Dance_Data.Models.Entities.Size", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("SizeDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Sizes");
                });

            modelBuilder.Entity("Booking_Dance_Data.Models.Entities.Studio", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("AccountId")
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("CategoryId")
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime?>("CreateAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeleteAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("ImageStudio")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("IsActive")
                        .HasColumnType("bit");

                    b.Property<decimal?>("Pricing")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("RatingId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StudioAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StudioDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StudioName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdateAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Studios");
                });

            modelBuilder.Entity("Booking_Dance_Data.Models.Entities.Voucher", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("AccountId")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreateAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeleteAt")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Discount")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<bool?>("IsActive")
                        .HasColumnType("bit");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<string>("StudioId")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime?>("UpdateAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.HasIndex("StudioId");

                    b.ToTable("Vouchers");
                });

            modelBuilder.Entity("Booking_Dance_Data.Models.Entities.Account", b =>
                {
                    b.HasOne("Booking_Dance_Data.Models.Entities.Role", "Role")
                        .WithMany("Accounts")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("Booking_Dance_Data.Models.Entities.Booking", b =>
                {
                    b.HasOne("Booking_Dance_Data.Models.Entities.Account", "Account")
                        .WithMany("Bookings")
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Booking_Dance_Data.Models.Entities.ClassDance", "ClassDance")
                        .WithMany()
                        .HasForeignKey("ClassId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Booking_Dance_Data.Models.Entities.Studio", "Studio")
                        .WithMany("Bookings")
                        .HasForeignKey("StudioId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Account");

                    b.Navigation("ClassDance");

                    b.Navigation("Studio");
                });

            modelBuilder.Entity("Booking_Dance_Data.Models.Entities.Capacity", b =>
                {
                    b.HasOne("Booking_Dance_Data.Models.Entities.Size", "Size")
                        .WithMany()
                        .HasForeignKey("SizeId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Booking_Dance_Data.Models.Entities.Studio", "Studio")
                        .WithMany()
                        .HasForeignKey("StudioId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Size");

                    b.Navigation("Studio");
                });

            modelBuilder.Entity("Booking_Dance_Data.Models.Entities.ClassDance", b =>
                {
                    b.HasOne("Booking_Dance_Data.Models.Entities.Account", "Account")
                        .WithMany()
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Booking_Dance_Data.Models.Entities.Studio", "Studio")
                        .WithMany()
                        .HasForeignKey("StudioId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Account");

                    b.Navigation("Studio");
                });

            modelBuilder.Entity("Booking_Dance_Data.Models.Entities.History", b =>
                {
                    b.HasOne("Booking_Dance_Data.Models.Entities.Payment", "Payment")
                        .WithMany("Histories")
                        .HasForeignKey("PaymentId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Payment");
                });

            modelBuilder.Entity("Booking_Dance_Data.Models.Entities.Image", b =>
                {
                    b.HasOne("Booking_Dance_Data.Models.Entities.Studio", "Studio")
                        .WithMany()
                        .HasForeignKey("StudioId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Studio");
                });

            modelBuilder.Entity("Booking_Dance_Data.Models.Entities.Noti", b =>
                {
                    b.HasOne("Booking_Dance_Data.Models.Entities.Account", "Account")
                        .WithMany("Notis")
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Account");
                });

            modelBuilder.Entity("Booking_Dance_Data.Models.Entities.Order", b =>
                {
                    b.HasOne("Booking_Dance_Data.Models.Entities.Booking", "Booking")
                        .WithMany("Orders")
                        .HasForeignKey("BookingId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Booking");
                });

            modelBuilder.Entity("Booking_Dance_Data.Models.Entities.Payment", b =>
                {
                    b.HasOne("Booking_Dance_Data.Models.Entities.Order", "Order")
                        .WithMany("Payments")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Order");
                });

            modelBuilder.Entity("Booking_Dance_Data.Models.Entities.Review", b =>
                {
                    b.HasOne("Booking_Dance_Data.Models.Entities.Account", "Account")
                        .WithMany("Reviews")
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Booking_Dance_Data.Models.Entities.Studio", "Studio")
                        .WithMany("Reviews")
                        .HasForeignKey("StudioId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Account");

                    b.Navigation("Studio");
                });

            modelBuilder.Entity("Booking_Dance_Data.Models.Entities.Studio", b =>
                {
                    b.HasOne("Booking_Dance_Data.Models.Entities.Account", "Account")
                        .WithMany("Studios")
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Booking_Dance_Data.Models.Entities.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Account");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Booking_Dance_Data.Models.Entities.Voucher", b =>
                {
                    b.HasOne("Booking_Dance_Data.Models.Entities.Account", "Account")
                        .WithMany("Vouchers")
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Booking_Dance_Data.Models.Entities.Studio", "Studio")
                        .WithMany("Vouchers")
                        .HasForeignKey("StudioId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Account");

                    b.Navigation("Studio");
                });

            modelBuilder.Entity("Booking_Dance_Data.Models.Entities.Account", b =>
                {
                    b.Navigation("Bookings");

                    b.Navigation("Notis");

                    b.Navigation("Reviews");

                    b.Navigation("Studios");

                    b.Navigation("Vouchers");
                });

            modelBuilder.Entity("Booking_Dance_Data.Models.Entities.Booking", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("Booking_Dance_Data.Models.Entities.Order", b =>
                {
                    b.Navigation("Payments");
                });

            modelBuilder.Entity("Booking_Dance_Data.Models.Entities.Payment", b =>
                {
                    b.Navigation("Histories");
                });

            modelBuilder.Entity("Booking_Dance_Data.Models.Entities.Role", b =>
                {
                    b.Navigation("Accounts");
                });

            modelBuilder.Entity("Booking_Dance_Data.Models.Entities.Studio", b =>
                {
                    b.Navigation("Bookings");

                    b.Navigation("Reviews");

                    b.Navigation("Vouchers");
                });
#pragma warning restore 612, 618
        }
    }
}
