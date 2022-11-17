using AsyncInnTake2_401_Lab.Data;
using Microsoft.EntityFrameworkCore;
using AsyncInnTake2_401_Lab.Models.Interfaces;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace AsyncInnTake2_401_Lab.Models.Services
{
    public class HotelService : IHotel
    {
        private readonly AsyncInnDbContext _asyncinnDbContext;
        public HotelService( AsyncInnDbContext asyncinnDbContext )
        {
            _asyncinnDbContext = asyncinnDbContext;
        }
        public async Task<Hotel> Create(Hotel hotel)
        {
          _asyncinnDbContext.Entry(hotel).State = EntityState.Added;
          await SaveChanges();
          
          return hotel; 
        }
        public async Task<Hotel> UpdateHotel(Hotel hotel)
        {
          _asyncinnDbContext.Update(hotel);
          SaveChanges();
          return hotel;  
        }
        public async Task<Hotel> Find(int? id)
        {
          return await _asyncinnDbContext.Hotels.FindAsync(id);
        }
       public async Task<Hotel> Delete(Hotel hotel)
       {
          _asyncinnDbContext.Hotels.Remove(hotel);
          return null;
       }
       public async Task<List<Hotel>> GetHotels()
       {
         // this is from the hotelscontroller method
         //await _context.Hotels.ToListAsync()
         return await _asyncinnDbContext.Hotels.ToListAsync();
       }
       public async Task<Hotel> GetHotel(int? id)
       {
          return await _asyncinnDbContext.Hotels.FirstOrDefaultAsync(m => m.Id == id);
       }

      public async Task<Hotel> SaveChanges()
      {
         await _asyncinnDbContext.SaveChangesAsync();
         return null;
      }

      public bool Exists(int id)
      {
        return _asyncinnDbContext.Hotels.Any(e => e.Id == id);
      }
    }
}
