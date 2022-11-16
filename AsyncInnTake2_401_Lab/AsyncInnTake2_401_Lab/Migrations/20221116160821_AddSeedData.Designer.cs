﻿// <auto-generated />
using AsyncInnTake2_401_Lab.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AsyncInnTake2401Lab.Migrations
{
    [DbContext(typeof(AsyncInnDbContext))]
    [Migration("20221116160821_AddSeedData")]
    partial class AddSeedData
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AsyncInnTake2_401_Lab.Models.Amenity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("AirConditioning")
                        .HasColumnType("bit");

                    b.Property<bool>("Coffee")
                        .HasColumnType("bit");

                    b.Property<bool>("Fridge")
                        .HasColumnType("bit");

                    b.Property<bool>("MiniBar")
                        .HasColumnType("bit");

                    b.Property<bool>("OceanView")
                        .HasColumnType("bit");

                    b.Property<bool>("PetFriendly")
                        .HasColumnType("bit");

                    b.Property<int>("RoomId")
                        .HasColumnType("int");

                    b.Property<bool>("Safe")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("RoomId");

                    b.ToTable("Amenities");

                    b.HasData(
                        new
                        {
                            Id = 51,
                            AirConditioning = true,
                            Coffee = false,
                            Fridge = true,
                            MiniBar = false,
                            OceanView = true,
                            PetFriendly = true,
                            RoomId = 101,
                            Safe = false
                        },
                        new
                        {
                            Id = 52,
                            AirConditioning = true,
                            Coffee = true,
                            Fridge = true,
                            MiniBar = false,
                            OceanView = false,
                            PetFriendly = false,
                            RoomId = 201,
                            Safe = false
                        },
                        new
                        {
                            Id = 53,
                            AirConditioning = true,
                            Coffee = false,
                            Fridge = true,
                            MiniBar = true,
                            OceanView = false,
                            PetFriendly = true,
                            RoomId = 301,
                            Safe = true
                        });
                });

            modelBuilder.Entity("AsyncInnTake2_401_Lab.Models.Hotel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumberOfRooms")
                        .HasColumnType("int");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Hotels");

                    b.HasData(
                        new
                        {
                            Id = 100,
                            Address = "P.Sherman 42 Wallaby Way",
                            City = "Sydney",
                            Name = "The Nemo",
                            NumberOfRooms = 42,
                            PhoneNumber = "555-555-5555",
                            State = "Australia"
                        },
                        new
                        {
                            Id = 200,
                            Address = "321 Broken Dreams Boulevard",
                            City = "Greenday",
                            Name = "The Green Day",
                            NumberOfRooms = 21,
                            PhoneNumber = "867-5309",
                            State = "Ohio"
                        },
                        new
                        {
                            Id = 300,
                            Address = "123 Hollywood Drive",
                            City = "Hollywood",
                            Name = "The Broadway",
                            NumberOfRooms = 77,
                            PhoneNumber = "911-911-9111",
                            State = "Iowa"
                        });
                });

            modelBuilder.Entity("AsyncInnTake2_401_Lab.Models.Room", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("HotelId")
                        .HasColumnType("int");

                    b.Property<bool>("IsPetFriendly")
                        .HasColumnType("bit");

                    b.Property<int>("Layout")
                        .HasColumnType("int");

                    b.Property<string>("Nickname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<int>("RoomNumber")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Rooms");

                    b.HasData(
                        new
                        {
                            Id = 101,
                            HotelId = 100,
                            IsPetFriendly = true,
                            Layout = 2,
                            Nickname = "The Butt",
                            Price = 475,
                            RoomNumber = 41
                        },
                        new
                        {
                            Id = 201,
                            HotelId = 200,
                            IsPetFriendly = false,
                            Layout = 0,
                            Nickname = "The American Idiot",
                            Price = 255,
                            RoomNumber = 20
                        },
                        new
                        {
                            Id = 301,
                            HotelId = 300,
                            IsPetFriendly = true,
                            Layout = 1,
                            Nickname = "The Globe",
                            Price = 670,
                            RoomNumber = 76
                        });
                });

            modelBuilder.Entity("AsyncInnTake2_401_Lab.Models.Amenity", b =>
                {
                    b.HasOne("AsyncInnTake2_401_Lab.Models.Room", null)
                        .WithMany("RoomAmenities")
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AsyncInnTake2_401_Lab.Models.Room", b =>
                {
                    b.Navigation("RoomAmenities");
                });
#pragma warning restore 612, 618
        }
    }
}
