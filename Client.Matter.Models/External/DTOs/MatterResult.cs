namespace Client.Matter.Models.External.DTOs
{
    public class MatterResult
    {
        public string ClientId { get; set; }
        public string MatterId { get; set; }
        public string MatterName { get; set; }
        public string MatterCode { get; set; }
        public DateTime MatterDate { get; set; }
    }
}