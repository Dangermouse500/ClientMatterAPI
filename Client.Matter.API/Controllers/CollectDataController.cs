namespace Client.Matter.API.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class CollectDataController(IClientMatterDataSource _clientMatterDataSource) : ClientMatterControllerBase
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> CollectAndSaveClientMatterDataAsync()
        {
            await _clientMatterDataSource.CollectAndSaveClientDataAsync();

            await _clientMatterDataSource.CollectAndSaveMatterDataAsync();

            return NoContent();
        }
    }
}