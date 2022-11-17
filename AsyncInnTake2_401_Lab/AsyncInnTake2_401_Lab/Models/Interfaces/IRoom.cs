namespace AsyncInnTake2_401_Lab.Models.Interfaces
{
    public interface IRoom
    {
     // CREATE
     Task<Room> Create( Room room );

     //UPDATE
     Task<Room> UpdateRoom( int? id );

     //DELETE
     Task<Room> Delete( int? id );

     // READ ONE
     Task<Room> GetRoom( int id );

     // READ ALL
     Task<List<Room>> GetRooms();
 }
}
