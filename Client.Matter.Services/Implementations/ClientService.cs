namespace Client.Matter.Services.Implementations
{
    public class ClientService(IMapper _mapper, IClientRepository _clientRepository) : IClientService
    {
        public async Task<ClientDto> GetClientByIdAsync(string clientId)
        {
            return _mapper.Map<ClientDto>(await _clientRepository.GetClientByIdAsync(clientId));
        }

        public async Task SaveClientAsync(ClientEf client)
        {
            await _clientRepository.SaveClientAsync(client);
        }

        public async Task SaveAddressAsync(AddressEf address)
        {
            await _clientRepository.SaveAddressAsync(address);
        }

        public async Task SavePersonAsync(PeopleEf person)
        {
            await _clientRepository.SavePersonAsync(person);
        }
    }
}