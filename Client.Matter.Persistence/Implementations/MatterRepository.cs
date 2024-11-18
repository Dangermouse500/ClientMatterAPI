namespace Client.Matter.Persistence.Implementations
{
    public class MatterRepository(ClientMatterDbContext _clientMatterDbContext) : IMatterRepository
    {
        public async Task<MatterEf> GetMatterByIdAsync(string matterId)
        {
            return await _clientMatterDbContext.Matters.FirstOrDefaultAsync(x => x.MatterId == matterId);
        }

        public async Task SaveMatterAsync(MatterEf matter)
        {
            await _clientMatterDbContext.Matters.AddAsync(matter);
        }

        public async Task<List<MatterEf>> GetMattersByQueryAsync(string clientId)
        {
            return await _clientMatterDbContext.Matters.Where(x => x.ClientId == clientId).ToListAsync();
        }
    }
}