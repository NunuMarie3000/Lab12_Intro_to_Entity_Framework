using AsyncInnTake2_401_Lab.Data;
using Microsoft.EntityFrameworkCore;

namespace AsyncInnTake2_401_Lab.Models.Services
{
    public class RoomService
    {
      private AsyncInnDbContext _asyncinnDbContext;
      public RoomService( AsyncInnDbContext asyncinnDbContext )
      {
       _asyncinnDbContext = asyncinnDbContext;
      }
      public async Task<Room> Create( Room room )
      {
       _asyncinnDbContext.Entry(room).State = EntityState.Added;
       await _asyncinnDbContext.SaveChangesAsync();
       return room;
      }
    }
}
