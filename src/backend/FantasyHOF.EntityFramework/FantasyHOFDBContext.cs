using FantasyHOF.Domain.Types;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace FantasyHOF.EntityFramework
{
    public class FantasyHOFDBContext : DbContext
    {
        public DbSet<League> Leagues => Set<League>();
        
        public FantasyHOFDBContext(DbContextOptions<FantasyHOFDBContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
