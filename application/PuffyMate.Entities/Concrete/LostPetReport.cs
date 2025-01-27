using BaseTestApp.Entities.Shared;

namespace PuffyMate.Entities.Concrete
{
    public class LostPetReport : BaseEntity
    {
        public string Description { get; set; }
        public DateTime ReportedAt { get; set; }
        public int ReporterId { get; set; }
        public AppUser Reporter { get; set; }
    }
}
