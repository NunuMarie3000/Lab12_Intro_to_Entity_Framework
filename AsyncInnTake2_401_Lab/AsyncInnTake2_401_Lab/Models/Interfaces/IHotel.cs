using AsyncInnTake2_401_Lab.Controllers;

namespace AsyncInnTake2_401_Lab.Models.Interfaces
{
    public interface IHotel
    {
     // CREATE
     Task<Hotel> Create(Hotel hotel);

     //UPDATE
     Task<Hotel> UpdateHotel( int? id );

     //DELETE
     Task<Hotel> Delete( int? id );

     // READ ONE
     Task<Hotel> GetHotel(int id);

     // READ ALL
     Task<List<Hotel>> GetHotels();
      
    }
}
