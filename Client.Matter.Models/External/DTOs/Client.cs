namespace Client.Matter.Models.External.DTOs
{
    public class Client
    {
        public string ClientId { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public DateTime InceptionDate { get; set; }
        public Address Address { get; set; }
        public List<People> People { get; set; }
        public int MatterCount { get; set; }
    }
}