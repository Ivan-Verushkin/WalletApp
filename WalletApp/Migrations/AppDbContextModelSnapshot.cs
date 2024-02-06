﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using WalletAppApi.Data;

#nullable disable

namespace WalletApp.Api.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("WalletAppApi.Models.TransactionDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ImagePath")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<bool>("Pending")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("TransactionDate")
                        .HasColumnType("timestamp");

                    b.Property<string>("TransactionDescription")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<decimal>("TransactionFee")
                        .HasColumnType("money");

                    b.Property<int>("TransactionInitializerUserId")
                        .HasColumnType("integer");

                    b.Property<string>("TransactionInitializerUserName")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<int>("TransactionListId")
                        .HasColumnType("integer");

                    b.Property<string>("TransactionName")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<short>("TransactionType")
                        .HasColumnType("smallint");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("TransactionListId");

                    b.HasIndex("UserId");

                    b.ToTable("TransactionDetails");
                });

            modelBuilder.Entity("WalletAppApi.Models.TransactionList", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<double>("CardBalance")
                        .HasColumnType("double precision");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("TransactionLists");
                });

            modelBuilder.Entity("WalletAppApi.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("WalletAppApi.Models.TransactionDetail", b =>
                {
                    b.HasOne("WalletAppApi.Models.TransactionList", "TransactionList")
                        .WithMany("TransactionDetails")
                        .HasForeignKey("TransactionListId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WalletAppApi.Models.User", "User")
                        .WithMany("TransactionDetails")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TransactionList");

                    b.Navigation("User");
                });

            modelBuilder.Entity("WalletAppApi.Models.TransactionList", b =>
                {
                    b.HasOne("WalletAppApi.Models.User", "User")
                        .WithOne("TransactionList")
                        .HasForeignKey("WalletAppApi.Models.TransactionList", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("WalletAppApi.Models.TransactionList", b =>
                {
                    b.Navigation("TransactionDetails");
                });

            modelBuilder.Entity("WalletAppApi.Models.User", b =>
                {
                    b.Navigation("TransactionDetails");

                    b.Navigation("TransactionList");
                });
#pragma warning restore 612, 618
        }
    }
}