using System.ComponentModel;

namespace AsyncInnTake2_401_Lab.Models
{
  public class Amenity
  {
    public int Id { get; set; }
    [DisplayName("Air Conditioning")]
    public bool AirConditioning { get; set; }
    public bool Coffee { get; set; }
    [DisplayName("Ocean View")]
    public bool OceanView { get; set; }
    public bool MiniBar { get; set; }
    public bool Fridge { get; set; }
    public bool Safe { get; set; }
    [DisplayName("Pet Friendly")]
    public bool PetFriendly { get; set; }
    //public Room RoomId { get; set; }
    public RoomAmenities Room { get; set; }
  }
}
