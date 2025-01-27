using BaseTestApp.Entities.Shared;

namespace PuffyMate.Entities.Concrete;

public class Listing : BaseEntity
{
    public ListingType Type { get; set; } // Sahiplendirme, Çiftleştirme, Kayıp, Bulundu
    public string Title { get; set; }
    public string Description { get; set; }
    public int PetId { get; set; }
    public int UserId { get; set; }


    public Pet Pet { get; set; }
    public AppUser User { get; set; }
}


public enum ListingType
{
    Adoption,
    Mating,
    Lost,
    Found
}
