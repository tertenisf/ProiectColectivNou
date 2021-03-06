﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProiectColectiv.Models;

namespace ProiectColectiv.Migrations
{
    [DbContext(typeof(ProiectColectivContext))]
    partial class ProiectColectivContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.3-servicing-35854")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ProiectColectiv.Models.Booking", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("End_Time");

                    b.Property<bool>("IsFastCharging");

                    b.Property<string>("PlateNumber");

                    b.Property<DateTime>("Start_Time");

                    b.Property<int?>("StationId");

                    b.Property<int>("Station_Id");

                    b.HasKey("Id");

                    b.HasIndex("StationId");

                    b.ToTable("Booking");
                });

            modelBuilder.Entity("ProiectColectiv.Models.Parking", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("Latitudine");

                    b.Property<double>("Longitudine");

                    b.Property<int>("MonthlyGain");

                    b.Property<string>("Name");

                    b.Property<int>("NrFastChargingSpots");

                    b.Property<int>("NrNormalChargingSpots");

                    b.Property<int>("WeeklyGain");

                    b.Property<bool>("isClosed");

                    b.HasKey("Id");

                    b.ToTable("Parkings");
                });

            modelBuilder.Entity("ProiectColectiv.Models.Station", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DailyGain");

                    b.Property<bool>("IsFastCharging");

                    b.Property<string>("MonthlyGain");

                    b.Property<int?>("ParkingId");

                    b.Property<string>("WeeklyGain");

                    b.Property<bool>("isEmpty");

                    b.HasKey("Id");

                    b.HasIndex("ParkingId");

                    b.ToTable("Stations");
                });

            modelBuilder.Entity("ProiectColectiv.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(60);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(60);

                    b.Property<string>("Password")
                        .IsRequired();

                    b.Property<bool>("isAdmin");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("ProiectColectiv.Models.Booking", b =>
                {
                    b.HasOne("ProiectColectiv.Models.Station")
                        .WithMany("bookings")
                        .HasForeignKey("StationId");
                });

            modelBuilder.Entity("ProiectColectiv.Models.Station", b =>
                {
                    b.HasOne("ProiectColectiv.Models.Parking")
                        .WithMany("Stations")
                        .HasForeignKey("ParkingId");
                });
#pragma warning restore 612, 618
        }
    }
}
