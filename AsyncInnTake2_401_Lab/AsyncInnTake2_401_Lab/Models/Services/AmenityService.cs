using AsyncInnTake2_401_Lab.Data;
using Microsoft.EntityFrameworkCore;

namespace AsyncInnTake2_401_Lab.Models.Services
{
    public class AmenityService
    {
      private AsyncInnDbContext _asyncinnDbContext;
      public AmenityService( AsyncInnDbContext asyncinnDbContext )
      {
       _asyncinnDbContext = asyncinnDbContext;
      }
      public async Task<Amenity> Create( Amenity amenity )
      {
       _asyncinnDbContext.Entry(amenity).State = EntityState.Added;
       await _asyncinnDbContext.SaveChangesAsync();
       return amenity;
      }
     }
}
