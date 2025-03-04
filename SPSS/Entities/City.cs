using System.ComponentModel.DataAnnotations;

namespace SPSS.Entities
{
    public class City
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(25)]
        public string Name { get; set; } = string.Empty;
    }
}
