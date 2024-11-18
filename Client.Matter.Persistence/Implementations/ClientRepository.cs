using Client.Matter.Models.Enums;

namespace Client.Matter.Persistence.Implementations
{
    public class ClientRepository(ClientMatterDbContext _clientMatterDbContext) : IClientRepository
    {
        public async Task<ClientEf> GetClientByIdAsync(string clientId)
        {
            return await _clientMatterDbContext.Clients
                                                .Include(x => x.Address)
                                                .Include(x => x.People)
                                                .FirstOrDefaultAsync(x => x.ClientId == clientId);
        }

        public async Task SaveClientAsync(ClientEf client)
        {
            await _clientMatterDbContext.Clients.AddAsync(client);
            await _clientMatterDbContext.SaveChangesAsync();
        }

        public async Task SaveAddressAsync(AddressEf address)
        {
            await _clientMatterDbContext.Addresses.AddAsync(address);
            await _clientMatterDbContext.SaveChangesAsync();
        }
        
        public async Task SavePersonAsync(PeopleEf person)
        {
            await _clientMatterDbContext.Peoples.AddAsync(person);
            await _clientMatterDbContext.SaveChangesAsync();
        }

        public async Task SaveMatterAsync(MatterEf matter)
        {
            await _clientMatterDbContext.Matters.AddAsync(matter);
            await _clientMatterDbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<ClientEf>> GetAllClientsAsync()
        {
            return await _clientMatterDbContext.Clients.ToArrayAsync();
        }

        public async Task<List<ClientEf>> GetClientsByQueryAsync(string searchTerm)
        {
            return await _clientMatterDbContext.Clients
                                                .Include(x => x.Address)
                                                .Include(x => x.People)
                                                .Where(x => x.Name.Contains(searchTerm)).ToListAsync();
        }

        public async Task<List<ClientEf>> GetClientsByQueryAsync(string searchTerm, ColumnOrder columnOrder, SortType sortType)
        {
            var clients = new List<ClientEf>();

            //This could be improved using extensions and the queryable Linq
            if (columnOrder == ColumnOrder.NAME)
            {
                if (sortType == SortType.DESCENDING)
                {
                    clients = await _clientMatterDbContext.Clients.Where(x => x.Name.Contains(searchTerm)).OrderByDescending(x => x.Name).ToListAsync();
                }
                else
                    clients = await _clientMatterDbContext.Clients.Where(x => x.Name.Contains(searchTerm)).OrderBy(x => x.Name).ToListAsync();
            }
            else
            {
                if (sortType == SortType.DESCENDING)
                {
                    clients = await _clientMatterDbContext.Clients.Where(x => x.Name.Contains(searchTerm)).OrderByDescending(x => x.InceptionDate).ToListAsync();
                }
                else
                    clients = await _clientMatterDbContext.Clients.Where(x => x.Name.Contains(searchTerm)).OrderBy(x => x.InceptionDate).ToListAsync();
            }

            return clients;
        }
    }
}