namespace Client.Matter.Services.External.Contracts
{
    public interface IClientMatterDataSource
    {
        Task CollectAndSaveClientDataAsync();
        Task CollectAndSaveMatterDataAsync();
    }
}