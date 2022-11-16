﻿using Microsoft.EntityFrameworkCore;
using AsyncInnTake2_401_Lab.Models;
using AsyncInnTake2_401_Lab.Data;
using Microsoft.EntityFrameworkCore.Design;

namespace AsyncInnTake2_401_Lab.Data
{
    public class AsyncInnDbContext : DbContext
    {
      public AsyncInnDbContext(DbContextOptions options) : base(options)
      {
        
      }

    readonly Hotel TheNemo = new Hotel { Address = "P.Sherman 42 Wallaby Way", City = "Sydney", State = "Australia", Id = 100, Name = "The Nemo", NumberOfRooms = 42, PhoneNumber = "555-555-5555" };
    readonly Hotel TheGreenDay = new Hotel { Address = "321 Broken Dreams Boulevard", City = "Greenday", State = "Ohio", Id = 200, Name = "The Green Day", NumberOfRooms = 21, PhoneNumber = "867-5309" };
    readonly Hotel TheBroadway = new Hotel { Address = "123 Hollywood Drive", City = "Hollywood", State = "Iowa", Id = 300, Name = "The Broadway", NumberOfRooms = 77, PhoneNumber = "911-911-9111" };

    readonly Amenity One = new Amenity { AirConditioning = true, Coffee = false, Fridge = true, Id = 51, MiniBar = false, OceanView = true, PetFriendly = true, Safe = false };

    readonly Amenity Two = new Amenity { AirConditioning = true, Coffee = true, Fridge = true, Id = 52, MiniBar = false, OceanView = false, PetFriendly = false, Safe = false };

    readonly Amenity Three = new Amenity { AirConditioning = true, Coffee = false, Fridge = true, Id = 53, MiniBar = true, OceanView = false, PetFriendly = true, Safe = true };

    protected override void OnModelCreating( ModelBuilder modelBuilder )
    {
      modelBuilder.Entity<Hotel>().HasData(TheNemo);
      modelBuilder.Entity<Hotel>().HasData(TheGreenDay);
      modelBuilder.Entity<Hotel>().HasData(TheBroadway);

      modelBuilder.Entity<Room>().HasData(new Room { Id = 101, HotelId = TheNemo, IsPetFriendly = true, Layout = 2, Nickname = "The Butt", Price = 475, RoomNumber = 41, RoomAmenities= One});
      modelBuilder.Entity<Room>().HasData(new Room { Id = 201, HotelId = TheGreenDay, IsPetFriendly = false, Layout = 0, Nickname = "The American Idiot", Price = 255, RoomNumber = 20, RoomAmenities=Two });
      modelBuilder.Entity<Room>().HasData(new Room { Id = 301, HotelId = TheBroadway, IsPetFriendly = true, Layout = 1, Nickname = "The Globe", Price = 670, RoomNumber = 76, RoomAmenities=Three });

      modelBuilder.Entity<Amenity>().HasData(One);
      modelBuilder.Entity<Amenity>().HasData(Two);
      modelBuilder.Entity<Amenity>().HasData(Three);
    }
    public DbSet<Hotel> Hotels { get; set; }
    public DbSet<Room> Rooms { get; set; }
    public DbSet<Amenity> Amenities { get; set; }
  }
}

public class YourDbContextFactory: IDesignTimeDbContextFactory<AsyncInnDbContext>
{
  public AsyncInnDbContext CreateDbContext( string[] args )
  {
    IConfigurationRoot configuration = new ConfigurationBuilder()
          .SetBasePath(Directory.GetCurrentDirectory())
          .AddJsonFile("appsettings.json")
          .Build();
    var connectionString = configuration.GetConnectionString("AzureConnectionString");
    var optionsBuilder = new DbContextOptionsBuilder<AsyncInnDbContext>();
    optionsBuilder.UseSqlServer(connectionString);

    return new AsyncInnDbContext(optionsBuilder.Options);
  }
}
