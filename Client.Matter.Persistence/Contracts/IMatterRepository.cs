namespace Client.Matter.Persistence.Contracts
{
    public interface IMatterRepository
    {
        Task<MatterEf> GetMatterByIdAsync(string matterId);
        Task SaveMatterAsync(MatterEf matter);
        Task<List<MatterEf>> GetMattersByQueryAsync(string searchTerm);
    }
}