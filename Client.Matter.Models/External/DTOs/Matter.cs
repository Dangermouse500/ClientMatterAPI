namespace Client.Matter.Models.External.DTOs
{
    public class Matter
    {
        public string ClientId { get; set; }
        public string MatterId { get; set; }
        public string MatterCode { get; set; }
        public string MatterName { get; set; }
        public string MatterDescription { get; set; }
        public DateTime MatterDate { get; set; }
    }
}