using System.ComponentModel;

namespace AsyncInnTake2_401_Lab.Models
{
  public class Hotel
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string Address { get; set; }
    [DisplayName("Phone Number")]
    public string PhoneNumber { get; set; }
    [DisplayName("Number of Rooms")]
    public int NumberOfRooms { get; set; }
  }
}
