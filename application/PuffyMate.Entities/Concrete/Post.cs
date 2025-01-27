using BaseTestApp.Entities.Shared;

namespace PuffyMate.Entities.Concrete;

public class Post : BaseEntity
{
    public string Content { get; set; }
    public string Description { get; set; }
    public string ImageUrl { get; set; }

    // Foreign Key
    public int PetId { get; set; }


    // Navigation Property
    public Pet Pet { get; set; }
    public ICollection<Comment> Comments { get; set; }
    public ICollection<Like> Likes { get; set; }
}
