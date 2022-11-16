using System.ComponentModel;

namespace AsyncInnTake2_401_Lab.Models
{
  public class Room
  {
    public int Id { get; set; }
    public string Nickname { get; set; }
    [DisplayName("Room Amenities")]
    public Amenity RoomAmenities { get; set; }
    public int Price { get; set; }
    public int RoomNumber { get; set; }
    [DisplayName("Is Pet Friendly")]
    public bool IsPetFriendly { get; set; }
    [DisplayName("Associated Hotel Id")]
    public Hotel AssociatedHotel { get; set; }
    public int Layout { get; set; }
  }
}
