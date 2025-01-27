using BaseTestApp.Entities.Shared;

namespace PuffyMate.Entities.Concrete;

public class Pet : BaseEntity
{
    public string Name { get; set; }
    public string Type { get; set; } // Kedi, köpek vs.
    public string Breed { get; set; } // Golden, british vs.
    public string Gender { get; set; }
    public string Description { get; set; }
    public DateTime BirthDate { get; set; }
    public string ProfilePictureUrl { get; set; }

    // Foreign Key
    public int OwnerId { get; set; }

    // Navigation Properties
    public AppUser Owner { get; set; }
    public ICollection<Post> Posts { get; set; }
}


//public enum PetType
//{
//    Dog,
//    Cat,
//    Bird,
//    Reptile,
//    Fish,
//    Other
//}

//public enum ListingType
//{
//    Adoption,
//    Mating,
//    Lost,
//    Found
//}