using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Colorado.Models
{
    public class NbarProtocol
    {
        [Key]
        public int id { get; set; }

        [Required]
        [DisplayName("Protocol Name")]
        public string protocol_name { get; set; }

        [DisplayName("Description")]
        public string protocol_description { get; set; }

        [Required]
        [DisplayName("Identification")]
        public string protocol_id { get; set; }
    }
}
