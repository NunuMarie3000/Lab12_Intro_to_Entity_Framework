namespace AsyncInnTake2_401_Lab.Models
{
  public class Amenity
  {
    public int Id { get; set; }
    public bool AirConditioning { get; set; }
    public bool Coffee { get; set; }
    public bool OceanView { get; set; }
    public bool MiniBar { get; set; }
    public bool Fridge { get; set; }
    public bool Safe { get; set; }
    public bool PetFriendly { get; set; }
    public int RoomId { get; set; }
  }
}
