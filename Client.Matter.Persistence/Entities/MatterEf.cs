namespace Client.Matter.Persistence.Entities
{
    [Table("Matter")]
    public class MatterEf
    {
        [Key]
        [Required]
        public string MatterId { get; set; }
        [Required]
        public string MatterCode { get; set; }
        [Required]
        public string MatterName { get; set; }
        public string MatterDescription { get; set; }
        [Required]
        public DateTime MatterDate { get; set; }

        [Required]
        public string ClientId { get; set; }
    }
}