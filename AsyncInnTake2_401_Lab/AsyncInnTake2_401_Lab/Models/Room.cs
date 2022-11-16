namespace AsyncInnTake2_401_Lab.Models
{
  public class Room
  {
    public int Id { get; set; }
    public string Nickname { get; set; }
    public ICollection<Amenity> RoomAmenities { get; set; }
    public int Price { get; set; }
    public int RoomNumber { get; set; }
    public bool IsPetFriendly { get; set; }
    public int HotelId { get; set; }
    public int Layout { get; set; }
  }
}
