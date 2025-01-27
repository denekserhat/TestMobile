using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PuffyMate.Entities.Concrete;

namespace BaseTestApp.DataAccess
{
    public class DataContext : IdentityDbContext<AppUser, AppUserRole, int>
    {


        public DbSet<Pet> Pets { get; set; }
        public DbSet<AppUserRole> AppUserRoles { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Like> Likes { get; set; }
        public DbSet<Listing> Listings { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<VeterinaryBlog> VeterinaryBlogs { get; set; }
        public DbSet<LostPetReport> LostPetReports { get; set; }
        public DbSet<UserBlock> UserBlocks { get; set; }
        public DbSet<Report> Reports { get; set; }


        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.HasDefaultSchema("application");

            #region Identity Tables Change Schema
            builder.Entity<AppUser>(entity => entity.ToTable(name: "Users", schema: "authentication"));
            builder.Entity<AppUserRole>(entity => entity.ToTable(name: "Roles", schema: "authentication"));
            builder.Entity<IdentityUserRole<int>>(entity => entity.ToTable(name: "UserRoles", schema: "authentication"));
            builder.Entity<IdentityUserLogin<int>>(entity => entity.ToTable(name: "UserLogins", schema: "authentication"));
            builder.Entity<IdentityUserToken<int>>(entity => entity.ToTable(name: "UserTokens", schema: "authentication"));
            builder.Entity<IdentityUserClaim<int>>(entity => entity.ToTable(name: "UserClaims", schema: "authentication"));
            builder.Entity<IdentityRoleClaim<int>>(entity => entity.ToTable(name: "RoleClaims", schema: "authentication"));
            #endregion

            #region Iliskiler
            builder.Entity<Comment>()
                .HasOne(c => c.AppUser)
                .WithMany(u => u.Comments)
                .HasForeignKey(c => c.UserId);

            builder.Entity<Comment>()
                .HasOne(c => c.Post)
                .WithMany(u => u.Comments)
                .HasForeignKey(c => c.UserId);

            builder.Entity<Like>()
                .HasOne(c => c.AppUser)
                .WithMany(u => u.Likes)
                .HasForeignKey(c => c.UserId);

            builder.Entity<Like>()
                .HasOne(c => c.Post)
                .WithMany(u => u.Likes)
                .HasForeignKey(c => c.UserId);

            builder.Entity<UserBlock>()
                .HasKey(ub => new { ub.BlockingUserId, ub.BlockedUserId });

            builder.Entity<UserBlock>()
                .HasOne(ub => ub.BlockingUser)
                .WithMany()
                .HasForeignKey(ub => ub.BlockingUserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<UserBlock>()
                .HasOne(ub => ub.BlockedUser)
                .WithMany()
                .HasForeignKey(ub => ub.BlockedUserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Post>()
                .HasOne(p => p.Pet)
                .WithMany(pet => pet.Posts)
                .HasForeignKey(p => p.PetId);

            builder.Entity<Message>()
                .HasOne(m => m.Sender)
                .WithMany(u => u.SentMessages)
                .HasForeignKey(m => m.SenderId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Message>()
                .HasOne(m => m.Receiver)
                .WithMany(u => u.ReceivedMessages)
                .HasForeignKey(m => m.ReceiverId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Report>()
                .HasOne(r => r.ReportedUser) // Şikayet edilen kullanıcı
                .WithMany(u => u.ReportedReports) // ApplicationUser'ın ReportedReports koleksiyonu
                .HasForeignKey(r => r.ReportedUserId) // ForeignKey: ReportedUserId
                .OnDelete(DeleteBehavior.Restrict); // Silme davranışı: Restrict

            builder.Entity<Report>()
                .HasOne(r => r.ReporterUser) // Şikayet eden kullanıcı
                .WithMany(u => u.ReporterReports) // ApplicationUser'ın ReporterReports koleksiyonu
                .HasForeignKey(r => r.ReporterUserId) // ForeignKey: ReporterUserId
                .OnDelete(DeleteBehavior.Restrict); // Silme davranışı: Restrict
            #endregion
        }
    }
}
