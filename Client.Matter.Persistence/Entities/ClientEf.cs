namespace Client.Matter.Persistence.Entities
{
    [Table("Client")]
    public class ClientEf
    {
        [Key]
        [Required]
        [StringLength(50)]
        public string ClientId { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        [Required]
        [StringLength(100)]
        public string Code { get; set; }
        [Required]
        [StringLength(500)]
        public string Description { get; set; }
        [Required]
        public DateTime InceptionDate { get; set; }
        
        public int AddressId { get; set; }
        public virtual AddressEf Address { get; set; }
        
        public virtual List<PeopleEf> People { get; set; }
        
        public int MatterCount { get; set; }
    }
}