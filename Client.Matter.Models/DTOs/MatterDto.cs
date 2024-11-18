namespace Client.Matter.Models.DTOs
{
    public class MatterDto
    {
        public string MatterId { get; set; }
        public string MatterCode { get; set; }
        public string MatterName { get; set; }
        public string MatterDescription { get; set; }
        public DateTime MatterDate { get; set; }
        public string ClientId { get; set; }
    }
}