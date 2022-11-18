using Microsoft.EntityFrameworkCore;
using AsyncInnTake2_401_Lab.Models;
using AsyncInnTake2_401_Lab.Data;
using Microsoft.EntityFrameworkCore.Design;

namespace AsyncInnTake2_401_Lab.Data
{
  public class AsyncInnDbContext: DbContext
  {
    public AsyncInnDbContext( DbContextOptions options ) : base(options)
    {

    }

    readonly Hotel TheNemo = new Hotel { Address = "P.Sherman 42 Wallaby Way", City = "Sydney", State = "Australia", Id = 100, Name = "The Nemo", NumberOfRooms = 42, PhoneNumber = "555-555-5555" };
    readonly Hotel TheGreenDay = new Hotel { Address = "321 Broken Dreams Boulevard", City = "Greenday", State = "Ohio", Id = 200, Name = "The Green Day", NumberOfRooms = 21, PhoneNumber = "867-5309" };
    readonly Hotel TheBroadway = new Hotel { Address = "123 Hollywood Drive", City = "Hollywood", State = "Iowa", Id = 300, Name = "The Broadway", NumberOfRooms = 77, PhoneNumber = "911-911-9111" };

  

    protected override void OnModelCreating( ModelBuilder modelBuilder )
    {
      Amenity One = new Amenity { AirConditioning = true, Coffee = false, Fridge = true, Id = 51, MiniBar = false, OceanView = true, PetFriendly = true, Safe = false };

      Amenity Two = new Amenity { AirConditioning = true, Coffee = true, Fridge = true, Id = 52, MiniBar = false, OceanView = false, PetFriendly = false, Safe = false };

      Amenity Three = new Amenity { AirConditioning = true, Coffee = false, Fridge = true, Id = 53, MiniBar = true, OceanView = false, PetFriendly = true, Safe = true };

      Room TheButt = new Room { Id = 101, AssociatedHotel = TheNemo.Name, IsPetFriendly = true, Layout = 2, Nickname = "The Butt", Price = 475, RoomNumber = 41 };
      Room TheAmericanIdiot = new Room { Id = 201, AssociatedHotel = TheGreenDay.Name, IsPetFriendly = false, Layout = 0, Nickname = "The American Idiot", Price = 255, RoomNumber = 20 };
      Room TheGlobe = new Room { Id = 301, AssociatedHotel = TheBroadway.Name, IsPetFriendly = true, Layout = 1, Nickname = "The Globe", Price = 670, RoomNumber = 76 };

      modelBuilder.Entity<RoomAmenities>().HasData(new RoomAmenities { Id=750, AmenitiesId = One.Id, RoomId = TheButt.Id });
      modelBuilder.Entity<RoomAmenities>().HasData(new RoomAmenities { Id = 751, AmenitiesId = Two.Id, RoomId = TheAmericanIdiot.Id });
      modelBuilder.Entity<RoomAmenities>().HasData(new RoomAmenities { Id = 752, AmenitiesId = Three.Id, RoomId = TheGlobe.Id });

      modelBuilder.Entity<Amenity>().HasData(One);
      modelBuilder.Entity<Amenity>().HasData(Two);
      modelBuilder.Entity<Amenity>().HasData(Three);

      modelBuilder.Entity<Room>().HasData(TheButt);
      modelBuilder.Entity<Room>().HasData(TheAmericanIdiot);
      modelBuilder.Entity<Room>().HasData(TheGlobe);

      modelBuilder.Entity<Hotel>().HasData(TheNemo);
      modelBuilder.Entity<Hotel>().HasData(TheGreenDay);
      modelBuilder.Entity<Hotel>().HasData(TheBroadway);

    }
    public DbSet<Hotel> Hotels { get; set; }
    public DbSet<Room> Rooms { get; set; }
    public DbSet<Amenity> Amenities { get; set; }
    public DbSet<RoomAmenities> RoomAmenitieses { get; set; }
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
