using BaseTestApp.Entities.Shared;

namespace PuffyMate.Entities.Concrete
{
    public class VeterinaryBlog : BaseEntity
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public int VeterinarianId { get; set; }
        public AppUser Veterinarian { get; set; }
    }
}
