using Microsoft.AspNetCore.Identity;

namespace PuffyMate.Entities.Concrete;

public class AppUser : IdentityUser<int>
{
    public string FullName { get; set; }
    public bool IsVeterinarian { get; set; }
    public string ProfilePictureUrl { get; set; }



    // Navigation Properties
    public ICollection<Pet> Pets { get; set; }
    public ICollection<Post> Posts { get; set; }
    public ICollection<Comment> Comments { get; set; }
    public ICollection<Like> Likes { get; set; }
    public ICollection<Message> SentMessages { get; set; }
    public ICollection<Message> ReceivedMessages { get; set; }
    public ICollection<Report> ReportedReports { get; set; }
    public ICollection<Report> ReporterReports { get; set; }
}