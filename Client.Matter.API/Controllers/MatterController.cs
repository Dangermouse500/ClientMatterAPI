namespace Client.Matter.API.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]/clientdata/matter")]
    [ApiVersion("1.0")]
    public class MatterController(IMatterService _matterService) : ClientMatterControllerBase
    {
        [HttpGet("id")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(MatterDto), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetMatterByIdAsync(string matterId)
        {
            var matter = await _matterService.GetMatterByIdAsync(matterId);
            if (matter == null)
            {
                return NotFoundProblem($"Matter Id '{matterId}' does not exist.");
            }

            return Ok(matter);
        }
    }
}