namespace Client.Matter.API.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]/clientdata/client")]
    [ApiVersion("1.0")]
    public class ClientController(IClientService _clientService) : ClientMatterControllerBase
    {
        [HttpGet("clientId")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(ClientDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ClientDto), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetClientByIdAsync(string clientId)
        {
            var client = await _clientService.GetClientByIdAsync(clientId);

            if (client == null)
            {
                return ClientNotFound(clientId);
            }

            return Ok(client);
        }
    }
}