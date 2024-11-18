namespace Client.Matter.API.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class ClientMatterSearchController(IClientMatterSearchService _clientMatterSearchService) : ClientMatterControllerBase
    {
        [HttpGet("clientsearch/{searchTerm}/{columnOrder}/{sort}/{index}/{offset}")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(IEnumerable<ClientDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]        
        public async Task<IActionResult> GetClientsByQueryAsync(string searchTerm, ColumnOrder columnOrder, SortType sort, int index, int offset)
        {//public async Task<IActionResult> GetClientsByQueryAsync(ClientSearchParameters clientSearchParameters)
            IEnumerable<ClientDto> clients = null;
            try
            {
                ClientSearchParameters clientSearchParameters = new ClientSearchParameters() { SearchTerm = searchTerm, ColumnOrder = columnOrder, Sort = sort, Index = index, Offset = offset };
                clients = await _clientMatterSearchService.GetClientsByQueryAsync(clientSearchParameters);
            }
            catch (ValidationException ex)
            {
                return BadRequestProblem(ex.Message);
            }
            
            return Ok(clients);
        }

        [HttpGet("clientdata/mattersearch/{clientId}/{columnOrder}/{sort}/{index}/{offset}")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(IEnumerable<MatterDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetMattersByQueryAsync(string clientId, ColumnOrder columnOrder, SortType sort, int index, int offset)
        {
            IEnumerable<MatterDto> matters = null;
            try
            {
                MatterSearchParameters matterSearchParameters = new MatterSearchParameters() { ClientId = clientId, ColumnOrder = columnOrder, Sort = sort, Index = index, Offset = offset };
                matters = await _clientMatterSearchService.GetMattersByQueryAsync(matterSearchParameters);
            }
            catch (ValidationException ex)
            {
                return BadRequestProblem(ex.Message);
            }

            return Ok(matters);
        }
    }
}