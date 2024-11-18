using Client.Matter.Models.External.DTOs;
using Client.Matter.Services.External.Contracts;
using Client.Matter.Services.External.Helpers;
using Microsoft.Extensions.Configuration;

namespace Client.Matter.Services.External.Implementations
{
    public class ClientMatterDataSource(HttpClient _httpClient, IConfiguration _configuration, IClientRepository _clientRepository) : IClientMatterDataSource
    {
        private readonly string _clientMatterDataSourceUri = _configuration["Services:ClientMatterDataSource:Uri"];
        private readonly string _clientMatterDataSourceApiKey = _configuration["Services:ClientMatterDataSource:ApiKey"];

        public async Task CollectAndSaveClientDataAsync()
        {
            string uri = _clientMatterDataSourceUri + "clientdata/clientsearch/d/DATE/ASCENDING/0/40";

            _httpClient.DefaultRequestHeaders.Add("Authorization", _clientMatterDataSourceApiKey);
            
            var clientSearchData = await ApiHelper.GetDataFromApi<ClientSearchResult>(_httpClient, uri);
            foreach (var item in clientSearchData.Results)
            {
                uri = _clientMatterDataSourceUri + "clientdata/client/" + item.ClientId;
                var clientData = await ApiHelper.GetDataFromApi<Client.Matter.Models.External.DTOs.Client>(_httpClient, uri);

                var addressEf = new AddressEf() { AddressLine1 = clientData.Address.AddressLine1, AddressLine2 = clientData.Address.AddressLine2, City = clientData.Address.City, County = clientData.Address.County, Postcode = clientData.Address.Postcode };
                await _clientRepository.SaveAddressAsync(addressEf);

                var clientEf = new ClientEf() { ClientId = clientData.ClientId, Code = clientData.Code, Description = clientData.Description, InceptionDate = clientData.InceptionDate, MatterCount = clientData.MatterCount, Name = clientData.Name, AddressId = addressEf.AddressId };
                await _clientRepository.SaveClientAsync(clientEf);

                foreach (var person in clientData.People)
                {
                    var peopleEf = new PeopleEf() { Email = person.Email, FirstName = person.FirstName, LastName = person.LastName, Phone = person.Phone, PreferredName = person.PreferredName, Title = person.Title, ClientId = clientEf.ClientId };
                    await _clientRepository.SavePersonAsync(peopleEf);
                }
            }
        }

        public async Task CollectAndSaveMatterDataAsync()
        {
            var clients = await _clientRepository.GetAllClientsAsync();
            foreach (var client in clients)
            {
                string uri = _clientMatterDataSourceUri + $"ClientData/mattersearch/{client.ClientId}/DATE/ASCENDING/0/5";

                var matterSearchData = await ApiHelper.GetDataFromApi<MatterSearchResult>(_httpClient, uri);

                foreach (var matterResult in matterSearchData.Results)
                {
                    uri = _clientMatterDataSourceUri + $"ClientData/matter/{matterResult.MatterId}";

                    var matterData = await ApiHelper.GetDataFromApi<Client.Matter.Models.External.DTOs.Matter>(_httpClient, uri);
                    if (matterData.ClientId != null)
                    {
                        var matterEf = new MatterEf() { ClientId = client.ClientId, MatterId = matterData.MatterId, MatterCode = matterData.MatterCode, MatterDate = matterData.MatterDate, MatterDescription = matterData.MatterDescription, MatterName = matterData.MatterName };
                        await _clientRepository.SaveMatterAsync(matterEf);
                    }
                }
            }
        }
    }
}