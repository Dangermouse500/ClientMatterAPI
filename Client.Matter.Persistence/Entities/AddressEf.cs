namespace Client.Matter.Persistence.Entities
{
    [Table("Address")]
    public class AddressEf
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AddressId { get; set; }
        [Required]
        [StringLength(50)]
        public string AddressLine1 { get; set; }
        [StringLength(50)]
        public string AddressLine2 { get; set; }
        [StringLength(50)]
        public string City { get; set; }
        [StringLength(50)]
        public string County { get; set; }
        [StringLength(10)]
        public string Postcode { get; set; }
    }
}