using System.ComponentModel.DataAnnotations;

namespace SPSS.Entities
{
    public class AddressType
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(25)]
        public string TypeName { get; set; } = string.Empty;
    }
}
