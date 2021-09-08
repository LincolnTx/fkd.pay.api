﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using fkd.pay.api.Data.Context;

namespace fkd.pay.api.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20210908235558_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("fkd.pay.api.Domain.Entities.PaymentCard", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<decimal>("AvailableBalance")
                        .HasColumnType("numeric")
                        .HasColumnName("available_balance");

                    b.Property<string>("CardHolderName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("card_holder_name");

                    b.Property<string>("CardNumber")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("card_number");

                    b.Property<int>("ExpMonth")
                        .HasColumnType("integer")
                        .HasColumnName("exp_month");

                    b.Property<int>("ExpYear")
                        .HasColumnType("integer")
                        .HasColumnName("exp_year");

                    b.Property<string>("_cvv")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("cvv");

                    b.HasKey("Id");

                    b.ToTable("payment_card");
                });
#pragma warning restore 612, 618
        }
    }
}
