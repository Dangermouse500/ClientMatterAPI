namespace Client.Matter.Persistence
{
    public class ClientMatterDbContext : DbContext
    {
        public ClientMatterDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<ClientEf> Clients { get; set; }
        public DbSet<AddressEf> Addresses { get; set; }
        public DbSet<PeopleEf> Peoples { get; set; }
        public DbSet<MatterEf> Matters { get; set; }
    }
}