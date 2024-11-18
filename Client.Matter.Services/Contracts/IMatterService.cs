namespace Client.Matter.Services.Contracts
{
    public interface IMatterService
    {
        Task<MatterDto> GetMatterByIdAsync(string matterId);
    }
}