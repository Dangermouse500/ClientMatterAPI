namespace Client.Matter.Models.External.DTOs
{
    public class ClientResult
    {
        public string ClientId { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public DateTime Inception { get; set; }
        public int MatterCount { get; set; }
    }
}