using BaseTestApp.Entities.Shared;

namespace PuffyMate.Entities.Concrete
{
    public class Report : BaseEntity
    {
        public string Description { get; set; }
        public bool IsResolved { get; set; } = false;

        // Foreign Keys
        public int ReportedUserId { get; set; }
        public int ReporterUserId { get; set; }


        // Navigation Properties
        public AppUser ReportedUser { get; set; }
        public AppUser ReporterUser { get; set; }
    }
}
