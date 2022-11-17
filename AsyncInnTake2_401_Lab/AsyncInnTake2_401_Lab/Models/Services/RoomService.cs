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
  }
}
