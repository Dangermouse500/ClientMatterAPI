using Microsoft.EntityFrameworkCore;

namespace Client.Matter.Persistence.UnitTests
{
    public class SqliteClientMatterDbContext : ClientMatterDbContext
    {
        public SqliteClientMatterDbContext(DbContextOptions options) : base(options)
        { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.AddInterceptors(new SqliteCommandInterceptor());
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}