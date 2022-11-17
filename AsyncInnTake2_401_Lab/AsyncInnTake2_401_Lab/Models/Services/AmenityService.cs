using AsyncInnTake2_401_Lab.Data;
using Microsoft.EntityFrameworkCore;
using AsyncInnTake2_401_Lab.Models.Interfaces;

namespace AsyncInnTake2_401_Lab.Models.Services
{
    public class AmenityService : IAmenity
    {
    private readonly AsyncInnDbContext _asyncinnDbContext;
    public AmenityService( AsyncInnDbContext asyncinnDbContext )
    {
      _asyncinnDbContext = asyncinnDbContext;
    }
    public async Task<Amenity> Create( Amenity amenity )
    {
      _asyncinnDbContext.Entry(amenity).State = EntityState.Added;

      return amenity;
    }
    public async Task<Amenity> UpdateAmenity( Amenity amenity )
    {
      _asyncinnDbContext.Update(amenity);
      SaveChanges();
      return amenity;
    }
    public async Task<Amenity> Find( int? id )
    {
      return await _asyncinnDbContext.Amenities.FindAsync(id);
    }
    public async Task<Amenity> Delete( Amenity amenity )
    {
      _asyncinnDbContext.Amenities.Remove(amenity);
      return null;
    }
    public async Task<List<Amenity>> GetAmenities()
    {
      return await _asyncinnDbContext.Amenities.ToListAsync();
    }
    public async Task<Amenity> GetAmenity( int? id )
    {
      return await _asyncinnDbContext.Amenities.FirstOrDefaultAsync(m => m.Id == id);
    }

    public async Task<Amenity> SaveChanges()
    {
      await _asyncinnDbContext.SaveChangesAsync();
      return null;
    }

    public bool Exists( int id )
    {
      return _asyncinnDbContext.Amenities.Any(e => e.Id == id);
    }
  }
}
