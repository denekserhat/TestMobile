using BaseTestApp.Entities.Shared;

namespace PuffyMate.Entities.Concrete;


public class Comment : BaseEntity
{
    public string Text { get; set; }


    // Foreign Keys
    public int UserId { get; set; }
    public int PostId { get; set; }

    // Navigation Properties
    public AppUser AppUser { get; set; }
    public Post Post { get; set; }
}