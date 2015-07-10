using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Colorado.Models
{
    public class Port
    {
        [Key]
        public int id { get; set; }

        [Required]
        [DisplayName("Greater or Equal")]
        [Range(0, 65535)]
        public int greater_or_equal { get; set; }

        [Required]
        [DisplayName("Less or Equal")]
        [Range(0,65535)]
        public int less_or_equal { get; set; }
    }
}
