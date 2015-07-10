using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Colorado.Models
{
    public class IpNetwork
    {
        [Key]
        public int id { get; set; }

        [Required]
        [DisplayName("IP Address")]
        [MinLength(7)]
        [MaxLength(15)]
        [RegularExpression("^[0-9]+\\.[0-9]+\\.[0-9]+\\.[0-9]+$")]  // IPv4
        public string address { get; set; }

        [Required]
        [DisplayName("IP Mask")]
        [Range(0,32)]
        public int mask { get; set; }
    }
}
