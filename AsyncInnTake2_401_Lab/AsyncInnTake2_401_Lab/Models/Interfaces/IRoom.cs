namespace AsyncInnTake2_401_Lab.Models.Interfaces
{
    public interface IRoom
    {
    // CREATE
    Task<Room> Create( Room room );

    //UPDATE
    Task<Room> UpdateRoom( Room room );

    //DELETE
    Task<Room> Delete( Room room );

    // READ ONE
    Task<Room> GetRoom( int? id );

    // READ ALL
    Task<List<Room>> GetRooms();

    // FIND
    Task<Room> Find( int? id );

    // Save
    Task<Room> SaveChanges();

    bool Exists( int id );

    // Add Amenities specific to room
    Task<Room> AddAmenityToRoom( int roomId, int amenityId );

    // Delete Amenities specific to room
    Task<Room> RemoveAmenityFromRoom(int roomId, int amenityId );
  }
}
