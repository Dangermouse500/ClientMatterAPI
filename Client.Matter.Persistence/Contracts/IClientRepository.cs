using Client.Matter.Models.Enums;

namespace Client.Matter.Persistence.Contracts
{
    public interface IClientRepository
    {
        Task<ClientEf> GetClientByIdAsync(string clientId);
        Task SaveClientAsync(ClientEf client);
        Task SaveAddressAsync(AddressEf address);
        Task SavePersonAsync(PeopleEf person);
        Task SaveMatterAsync(MatterEf matter);
        Task<IEnumerable<ClientEf>> GetAllClientsAsync();
        Task<List<ClientEf>> GetClientsByQueryAsync(string searchTerm);
        Task<List<ClientEf>> GetClientsByQueryAsync(string searchTerm, ColumnOrder columnOrder, SortType sortType);
    }
}