using DataDomenLevel.data;
using System.Data.Entity;

namespace DataAccessLevel
{
    class ApplicationDBContext : DbContext
    {
        public DbSet<AdministratorData> Administrators { get; set; }
    
        public ApplicationDBContext() : base("ApplicationDB-EF6CodeFirst")
        {
            Database.SetInitializer<ApplicationDBContext>(new ApplicationDBInitializer());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // User-Avatar One-to-Zero-or-One
            modelBuilder.Entity<UserData>()
                        .HasOptional(u => u.Avatar)
                        .WithRequired(a => a.User);

            // User-Videos One-to-Many
            modelBuilder.Entity<VideoData>()
                .HasRequired<UserData>(v => v.Author)
                .WithMany(u => u.Videos)
                .HasForeignKey<int>(v => v.UserId);

            // Video-Reports One-to-Many
            modelBuilder.Entity<ReportData>()
                .HasRequired<VideoData>(r => r.Video)
                .WithMany(v => v.Reports)
                .HasForeignKey<int>(r => r.VideoId);

            // Administrators-Reports Many-to-Many
            modelBuilder.Entity<AdministratorData>()
                .HasMany<ReportData>(a => a.Reports)
                .WithMany(r => r.Administrators)
                .Map(cs =>
                {
                    cs.MapLeftKey("AdministratorRefId");
                    cs.MapRightKey("ReportRefId");
                    cs.ToTable("Administrator_Report");
                });
        }
    }
}
