namespace Client.Matter.Services.Contracts
{
    public interface IClientMatterSearchService
    {
        Task<List<ClientDto>> GetClientsByQueryAsync(ClientSearchParameters clientSearchParameters);
        Task<List<MatterDto>> GetMattersByQueryAsync(MatterSearchParameters matterSearchParameters);
    }
}