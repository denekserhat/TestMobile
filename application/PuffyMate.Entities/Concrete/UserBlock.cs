namespace PuffyMate.Entities.Concrete
{
    public class UserBlock
    {
        public int BlockingUserId { get; set; }
        public AppUser BlockingUser { get; set; }
        public int BlockedUserId { get; set; }
        public AppUser BlockedUser { get; set; }
    }
}
