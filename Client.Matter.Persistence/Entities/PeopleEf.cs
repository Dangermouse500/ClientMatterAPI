namespace Client.Matter.Persistence.Entities
{
    [Table("People")]
    [Index(nameof(PeopleId), nameof(ClientId), IsUnique = true)]
    public class PeopleEf
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PeopleId { get; set; }
        [Required]
        [StringLength(25)]
        public string Title { get; set; }
        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(50)]
        public string LastName { get; set; }
        [StringLength(50)]
        public string PreferredName { get; set; }
        [Required]
        [StringLength(100)]
        public string Email { get; set; }
        [Required]
        [StringLength(50)]
        public string Phone { get; set; }

        [Required]
        [ForeignKey(nameof(ClientEf))]
        [Column("ClientId")]
        [StringLength(50)]
        public string ClientId { get; set; }
        public virtual ClientEf Client { get; set; }
    }
}