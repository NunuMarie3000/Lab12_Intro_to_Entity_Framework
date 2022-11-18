using AsyncInnTake2_401_Lab.Data;
using Microsoft.EntityFrameworkCore;
using AsyncInnTake2_401_Lab.Models.Interfaces;

namespace AsyncInnTake2_401_Lab.Models.Services
{
    public class RoomService : IRoom
    {
    private readonly AsyncInnDbContext _asyncinnDbContext;
    public RoomService( AsyncInnDbContext asyncinnDbContext )
    {
      _asyncinnDbContext = asyncinnDbContext;
    }
    public async Task<Room> Create( Room room )
    {
      _asyncinnDbContext.Entry(room).State = EntityState.Added;

      return room;
    }
    public async Task<Room> UpdateRoom( Room room )
    {
      _asyncinnDbContext.Update(room);
      SaveChanges();
      return room;
    }
    public async Task<Room> Find( int? id )
    {
      return await _asyncinnDbContext.Rooms.FindAsync(id);
    }
    public async Task<Room> Delete( Room room )
    {
      _asyncinnDbContext.Rooms.Remove(room);
      return null;
    }
    public async Task<List<Room>> GetRooms()
    {
      return await _asyncinnDbContext.Rooms.ToListAsync();
    }
    public async Task<Room> GetRoom( int? id )
    {
      return await _asyncinnDbContext.Rooms.FirstOrDefaultAsync(m => m.Id == id);
    }

    public async Task<Room> SaveChanges()
    {
      await _asyncinnDbContext.SaveChangesAsync();
      return null;
    }

    public bool Exists( int id )
    {
      return _asyncinnDbContext.Rooms.Any(e => e.Id == id);
    }

    public Task<Room> AddAmenityToRoom( int roomId, int amenityId )
    {
      var chosenOne = _asyncinnDbContext.Rooms.Where(room => room.Id == roomId);
      // what are we doing here? add the entire amenity class to a room, why do we have an amenityId though?
      // if we're adding the amenity...you know, perhaps we're assuming it's already created and we're simply adding it to the context
      // do we also need to join the amenity to the room then? using the room's RoomAmenities class?
      foreach(var item in chosenOne)
      {
        RoomAmenities newroomamenities = new RoomAmenities { RoomId=roomId, AmenitiesId=amenityId};

      }

      return null;
    }

    public Task<Room> RemoveAmenityFromRoom( int roomId, int amenityId )
    {
      // what is the best way to do this? we wanna be able to remove amenity from the room
      // or do we wanna remove the entire amenity object?
      // i'll just remove the entire object, that's easiest...
      var chosenOne = _asyncinnDbContext.Rooms.Where(room => room.Id == roomId && room.RoomAmenities.AmenitiesId== amenityId);
      _asyncinnDbContext.Remove(chosenOne);
      return null;
    }
  }
}
