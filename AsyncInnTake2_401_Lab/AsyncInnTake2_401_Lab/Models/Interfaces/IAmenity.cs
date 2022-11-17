namespace AsyncInnTake2_401_Lab.Models.Interfaces
{
    public interface IAmenity
    {
     // CREATE
     Task<Amenity> Create( Amenity amenity );

     //UPDATE
     Task<Amenity> UpdateAmenity( int? id );

     //DELETE
     Task<Amenity> Delete( int? id );

     // READ ONE
     Task<Amenity> GetAmenity( int id );

     // READ ALL
     Task<List<Amenity>> GetAmenities();
 }
}
