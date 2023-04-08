
using System.ComponentModel.DataAnnotations;

namespace SuperHeroApi
{
    public class SuperHero
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        [Required(AllowEmptyStrings = true)]
        public string? FristName { get; set; } = string.Empty;
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        [Required(AllowEmptyStrings = true)]
        public string? LastName { get; set; } = string.Empty;
        public string? Place { get; set; } = string.Empty;
    }
}
