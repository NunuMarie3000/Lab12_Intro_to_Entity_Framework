using AsyncInnTake2_401_Lab.Data;
using Microsoft.EntityFrameworkCore;

namespace AsyncInnTake2_401_Lab.Models.Services
{
    public class HotelService
    {
        private AsyncInnDbContext _asyncinnDbContext;
        public HotelService( AsyncInnDbContext asyncinnDbContext )
        {
            _asyncinnDbContext = asyncinnDbContext;
        }
        public async Task<Hotel> Create(Hotel hotel)
        {
          _asyncinnDbContext.Entry(hotel).State = EntityState.Added;
          await _asyncinnDbContext.SaveChangesAsync();
          return hotel; 
        }
    }
}
