namespace Client.Matter.API.Controllers
{
    [ApiController]
    public class ClientMatterControllerBase : ControllerBase
    {
        [NonAction]
        public virtual NotFoundObjectResult ClientNotFound(string clientId)
            => NotFoundProblem($"Client '{clientId}' is not found.");

        [NonAction]
        public virtual NotFoundObjectResult NotFoundProblem(string detail)
            => new(Problem(detail: detail, statusCode: 404).Value);

        [NonAction]
        public virtual BadRequestObjectResult BadRequestProblem(string detail)
            => new(Problem(detail: detail, statusCode: 400).Value);
        
        [NonAction]
        public virtual BadRequestObjectResult ConflictProblem(string detail)
            => new(Problem(detail: detail, statusCode: 409).Value);
    }
}