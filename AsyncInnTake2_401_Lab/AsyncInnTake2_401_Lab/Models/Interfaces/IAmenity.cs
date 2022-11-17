namespace AsyncInnTake2_401_Lab.Models.Interfaces
{
    public interface IAmenity
    {
    // CREATE
      Task<Amenity> Create( Amenity amenity );

      //UPDATE
      Task<Amenity> UpdateAmenity( Amenity amenity );

      //DELETE
      Task<Amenity> Delete( Amenity amenity );

      // READ ONE
      Task<Amenity> GetAmenity( int? id );

      // READ ALL
      Task<List<Amenity>> GetAmenities();

      // FIND
      Task<Amenity> Find( int? id );

      // Save
      Task<Amenity> SaveChanges();

      bool Exists( int id );
  }
}
