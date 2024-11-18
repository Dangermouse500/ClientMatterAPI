namespace Client.Matter.Services.Implementations
{
    public class ClientMatterSearchService(IMapper _mapper, IClientRepository _clientRepository, IMatterRepository _matterRepository) : IClientMatterSearchService
    {
        public async Task<List<ClientDto>> GetClientsByQueryAsync(ClientSearchParameters clientSearchParameters)
        {
            if (clientSearchParameters.Offset < 1 || clientSearchParameters.Offset > 50)
            {
                throw new ValidationException("Offset must be between 1 and 50.");
            }
            if (clientSearchParameters.Index < 0)
            {
                throw new ValidationException("Index must be greater than 0.");
            }

            var columnOrder = clientSearchParameters.ColumnOrder ?? Models.Enums.ColumnOrder.NAME;
            var clients = await _clientRepository.GetClientsByQueryAsync(clientSearchParameters.SearchTerm);

            var pagedClients = clients.Skip(clientSearchParameters.Index).Take(clientSearchParameters.Offset);

            return _mapper.Map<List<ClientDto>>(pagedClients);
        }
        
        public async Task<List<MatterDto>> GetMattersByQueryAsync(MatterSearchParameters matterSearchParameters)
        {
            if (matterSearchParameters.Offset < 1 || matterSearchParameters.Offset > 50)
            {
                throw new ValidationException("Offset must be between 1 and 50.");
            }
            if (matterSearchParameters.Index < 0)
            {
                throw new ValidationException("Index must be greater than 0.");
            }

            var matters = await _matterRepository.GetMattersByQueryAsync(matterSearchParameters.ClientId);
            if (matters == null || matters.Count == 0)
            {
                throw new ValidationException($"Client Id '{matterSearchParameters.ClientId}' does not exist.");
            }

            var columnOrder = matterSearchParameters.ColumnOrder ?? Models.Enums.ColumnOrder.NAME;
            var pagedMatters = matters.Skip(matterSearchParameters.Index).Take(matterSearchParameters.Offset);
            
            return _mapper.Map<List<MatterDto>>(pagedMatters);
        }
    }
}