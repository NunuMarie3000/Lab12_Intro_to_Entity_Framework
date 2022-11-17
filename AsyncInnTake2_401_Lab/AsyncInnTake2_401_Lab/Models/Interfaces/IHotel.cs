using AsyncInnTake2_401_Lab.Controllers;

namespace AsyncInnTake2_401_Lab.Models.Interfaces
{
    public interface IHotel
    {
     // CREATE
     Task<Hotel> Create(Hotel hotel);

     //UPDATE
     Task<Hotel> UpdateHotel( Hotel hotel );

     //DELETE
     Task<Hotel> Delete( Hotel hotel );

     // READ ONE
     Task<Hotel> GetHotel(int? id);

     // READ ALL
     Task<List<Hotel>> GetHotels();

      // FIND
      Task<Hotel> Find( int? id );

      // Save
      Task<Hotel> SaveChanges();

      bool Exists(int id);


    }
}
