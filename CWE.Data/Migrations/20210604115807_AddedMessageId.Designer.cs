﻿// <auto-generated />
using System;
using CWE.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CWE.Data.Migrations
{
    [DbContext(typeof(CWEDbContext))]
    [Migration("20210604115807_AddedMessageId")]
    partial class AddedMessageId
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.5");

            modelBuilder.Entity("CWE.Data.Models.Campaign", b =>
                {
                    b.Property<ulong>("User")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint unsigned");

                    b.Property<DateTime>("End")
                        .HasColumnType("datetime(6)");

                    b.Property<ulong>("Initiator")
                        .HasColumnType("bigint unsigned");

                    b.Property<ulong>("Message")
                        .HasColumnType("bigint unsigned");

                    b.Property<int>("Minimal")
                        .HasColumnType("int");

                    b.Property<string>("Reason")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("Start")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("User");

                    b.ToTable("Campaigns");
                });

            modelBuilder.Entity("CWE.Data.Models.Request", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("longtext");

                    b.Property<ulong>("Initiator")
                        .HasColumnType("bigint unsigned");

                    b.Property<ulong>("MessageId")
                        .HasColumnType("bigint unsigned");

                    b.Property<int>("State")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Requests");
                });
#pragma warning restore 612, 618
        }
    }
}
