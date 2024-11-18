using Client.Matter.Models.Enums;

namespace Client.Matter.Models.Parameters
{
    public class ClientSearchParameters : IValidatableObject
    {
        /// <summary>
        /// This is the filter you wish to apply to search by client's name.
        /// </summary>
        [Required]
        public string SearchTerm { get; set; }
        public ColumnOrder? ColumnOrder { get; set; }
        [Required]
        public SortType Sort { get; set; }
        [Required]
        public int Index { get; set; }
        [Range(1, 50)]
        [Required]
        public int Offset { get; set; }

        //This could be used if using a Post
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Index < 0)
            {
                yield return new ValidationResult("The Index must be 0 or greater.");
            }
            if (ColumnOrder.HasValue && !Enum.IsDefined(typeof(ColumnOrder), ColumnOrder))
            {
                yield return new ValidationResult("Column Order value does not exist.");
            }
            if (!Enum.IsDefined(typeof(SortType), Sort))
            {
                yield return new ValidationResult("Sort value does not exist.");
            }
        }
    }
}