namespace AsyncInnTake2_401_Lab.Models
{
    public class RoomAmenities
    {
      public int Id { get; set; }
      public int AmenitiesId { get; set; }
      public int RoomId { get; set; }
      public Amenity Amenities { get; set; }
      public Room Room { get; set; }
    }
}
