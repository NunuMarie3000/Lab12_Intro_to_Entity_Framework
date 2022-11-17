﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace AsyncInnTake2_401_Lab.Models
{
  public class Room
  {
    public int Id { get; set; }
    public string Nickname { get; set; }
    [DisplayName("Room Amenities")]
    //[ForeignKey("RoomAmenitiesId")]
    //public int RoomAmenities { get; set; }
    public int RoomAmenities { get; set; }
    public int Price { get; set; }
    public int RoomNumber { get; set; }
    [DisplayName("Is Pet Friendly")]
    public bool IsPetFriendly { get; set; }
    [DisplayName("Associated Hotel")]
    //public Hotel AssociatedHotel { get; set; }
    //public int AssociatedHotelId { get; set; }
    public string AssociatedHotel { get; set; }
    public int Layout { get; set; }
  }
}
