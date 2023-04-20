using Microsoft.EntityFrameworkCore;

namespace HalloASPMVC.Data
{
    public class HalloASPMVCContext : DbContext
    {
        public HalloASPMVCContext(DbContextOptions<HalloASPMVCContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string conString = "Server=(localdb)\\mssqllocaldb;Database=halloASP;Trusted_Connection=true;TrustServerCertificate=true;";
            optionsBuilder.UseSqlServer(conString);
        }

        public DbSet<HalloASPMVC.Models.Kunde> Kunde { get; set; } = default!;
    }
}
