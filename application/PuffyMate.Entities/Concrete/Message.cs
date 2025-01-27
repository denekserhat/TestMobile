using BaseTestApp.Entities.Shared;

namespace PuffyMate.Entities.Concrete;


public class Message : BaseEntity
{
    public string Content { get; set; }
    public bool IsRead { get; set; }


    // Foreign Keys
    public int SenderId { get; set; }
    public int ReceiverId { get; set; }


    // Navigation Properties
    public AppUser Sender { get; set; }
    public AppUser Receiver { get; set; }
}