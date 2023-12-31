﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using ProjectForTaqsim.Context;

#nullable disable

namespace ProjectForTaqsim.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230819155353_Init")]
    partial class Init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ProjectForTaqsim.Entities.Event", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<long>("PalaceId")
                        .HasColumnType("bigint");

                    b.Property<long>("Price")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("PalaceId");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("ProjectForTaqsim.Entities.Palace", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<long>("Capacity")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<long>("Row")
                        .HasColumnType("bigint");

                    b.Property<long>("SeatInRow")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("Palaces");
                });

            modelBuilder.Entity("ProjectForTaqsim.Entities.Seat", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<long>("EventId")
                        .HasColumnType("bigint");

                    b.Property<bool>("IsBusy")
                        .HasColumnType("boolean");

                    b.Property<long>("Row")
                        .HasColumnType("bigint");

                    b.Property<long>("SeatInRow")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("EventId");

                    b.ToTable("Seats");
                });

            modelBuilder.Entity("ProjectForTaqsim.Entities.Ticket", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<long>("EventId")
                        .HasColumnType("bigint");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<long>("Row")
                        .HasColumnType("bigint");

                    b.Property<long>("Seat")
                        .HasColumnType("bigint");

                    b.Property<string>("Secret")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("EventId");

                    b.ToTable("Tickets");
                });

            modelBuilder.Entity("ProjectForTaqsim.Entities.Event", b =>
                {
                    b.HasOne("ProjectForTaqsim.Entities.Palace", "Palace")
                        .WithMany("Events")
                        .HasForeignKey("PalaceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Palace");
                });

            modelBuilder.Entity("ProjectForTaqsim.Entities.Seat", b =>
                {
                    b.HasOne("ProjectForTaqsim.Entities.Event", "Event")
                        .WithMany("Seats")
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Event");
                });

            modelBuilder.Entity("ProjectForTaqsim.Entities.Ticket", b =>
                {
                    b.HasOne("ProjectForTaqsim.Entities.Event", "Event")
                        .WithMany("Tickets")
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Event");
                });

            modelBuilder.Entity("ProjectForTaqsim.Entities.Event", b =>
                {
                    b.Navigation("Seats");

                    b.Navigation("Tickets");
                });

            modelBuilder.Entity("ProjectForTaqsim.Entities.Palace", b =>
                {
                    b.Navigation("Events");
                });
#pragma warning restore 612, 618
        }
    }
}
