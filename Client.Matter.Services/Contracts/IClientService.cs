namespace Client.Matter.Services.Contracts
{
    public interface IClientService
    {
        Task<ClientDto> GetClientByIdAsync(string clientId);
        Task SaveClientAsync(ClientEf client);
        Task SaveAddressAsync(AddressEf address);
        Task SavePersonAsync(PeopleEf person);
    }
}