using Microsoft.EntityFrameworkCore;
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

    protected override void OnModelCreating( ModelBuilder modelBuilder )
    {
      modelBuilder.Entity<Hotel>().HasData(new Hotel { Address = "P.Sherman 42 Wallaby Way", City = "Sydney", State = "Australia", Id = 100, Name = "The Nemo", NumberOfRooms = 42, PhoneNumber = "555-555-5555" });
      modelBuilder.Entity<Hotel>().HasData(new Hotel { Address = "321 Broken Dreams Boulevard", City = "Greenday", State = "Ohio", Id = 200, Name = "The Green Day", NumberOfRooms = 21, PhoneNumber = "867-5309" });
      modelBuilder.Entity<Hotel>().HasData(new Hotel { Address = "123 Hollywood Drive", City = "Hollywood", State = "Iowa", Id = 300, Name = "The Broadway", NumberOfRooms = 77, PhoneNumber = "911-911-9111" });

      modelBuilder.Entity<Room>().HasData(new Room { Id = 101, HotelId = 100, IsPetFriendly = true, Layout = 2, Nickname = "The Butt", Price = 475, RoomNumber = 41 });
      modelBuilder.Entity<Room>().HasData(new Room { Id = 201, HotelId = 200, IsPetFriendly = false, Layout = 0, Nickname = "The American Idiot", Price = 255, RoomNumber = 20 });
      modelBuilder.Entity<Room>().HasData(new Room { Id = 301, HotelId = 300, IsPetFriendly = true, Layout = 1, Nickname = "The Globe", Price = 670, RoomNumber = 76 });

      modelBuilder.Entity<Amenity>().HasData(new Amenity { RoomId = 101, AirConditioning = true, Coffee = false, Fridge = true, Id = 51, MiniBar = false, OceanView = true, PetFriendly = true, Safe = false });
      modelBuilder.Entity<Amenity>().HasData(new Amenity { RoomId = 201, AirConditioning = true, Coffee = true, Fridge = true, Id = 52, MiniBar = false, OceanView = false, PetFriendly = false, Safe = false });
      modelBuilder.Entity<Amenity>().HasData(new Amenity { RoomId = 301, AirConditioning = true, Coffee = false, Fridge = true, Id = 53, MiniBar = true, OceanView = false, PetFriendly = true, Safe = true });
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
