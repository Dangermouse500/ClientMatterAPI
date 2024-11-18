namespace Client.Matter.Models.DTOs
{
    public class ClientDto
    {
        public string ClientId { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public DateTime InceptionDate { get; set; }
        public AddressDto Address { get; set; }
        public List<PeopleDto> People { get; set; }
        public int MatterCount { get; set; }
    }
}