using Microsoft.EntityFrameworkCore;

namespace KolokwiumPoprawkowe.Models
{
    public class MainDbContext : DbContext
    {
        protected MainDbContext()
        {
        }
        public MainDbContext(DbContextOptions options) : base(options)
        {
        }

        public  DbSet<Team> Teams { get; set; }
        public  DbSet<Member> Members { get; set; }
        public  DbSet<Membership> Memberships { get; set; }
        public  DbSet<Organization> Organizations { get; set; }
        public  DbSet<File> Files { get; set; }

        /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
        {
            optionsBuilder.UseSqlServer("Data Source=db-mssql16.pjwstk.edu.pl;Initial Catalog=s20636;Integrated Security=True");
        }*/

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Member>(p => 
            {
                p.HasOne(d => d.Organization)
                   .WithMany(p => p.Members)
                   .OnDelete(DeleteBehavior.Restrict);
                p.HasData(
                    new Member{MemberId = 1, OrganizationId = 1, MemberName = "A", MemberSurname = "B" }
                    );
            });

            modelBuilder.Entity<Membership>(p =>
            {
                p.HasKey(p => new { p.MemberId, p.TeamId });
                p.HasOne(d => d.Member)
                    .WithMany(p => p.Memberships)
                    .IsRequired()
                    .OnDelete(DeleteBehavior.Restrict);
                p.HasOne(d => d.Team)
                   .WithMany(p => p.Memberships)
                   .IsRequired()
                    .OnDelete(DeleteBehavior.Restrict);
                p.HasData(
                new Membership {MemberId = 1, TeamId = 1, MembershipDate = new System.DateTime(2022, 1, 1) }
                    );
            });

            modelBuilder.Entity<File>(p =>
            {
                p.HasKey(p => new { p.FileId, p.TeamId });
                p.HasOne(d => d.Team)
                   .WithMany(p => p.Files)
                   .IsRequired()
                    .OnDelete(DeleteBehavior.Restrict);
                p.HasData(
                new File {FileId = 1, TeamId = 1, FileName = "File", FileExtension = "txt", FileSize = 100 }
                    );

            });

            modelBuilder.Entity<Team>(p =>
            {             

                p.HasData(
                new Team { TeamId = 1, OrganizationId = 1, TeamName = "Team", TeamDescription = "A"}
                    );

        });
            modelBuilder.Entity<Organization>(p =>
            {
                p.HasMany(p => p.Teams)
                .WithOne(p => p.Organization)
                .OnDelete(DeleteBehavior.Restrict);
                p.HasData(
                    new Organization { OrganizationId = 1, OrganizationName = "PJATK", OrganizationDomain = "BBB" }
                    );
                
            });
     
        }
        
    }
}
