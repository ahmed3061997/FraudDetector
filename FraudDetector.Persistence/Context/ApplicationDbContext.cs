using FraudDetector.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FraudDetector.Persistence.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<FraudFlag> FraudFlags { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) =>
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

    }
}
