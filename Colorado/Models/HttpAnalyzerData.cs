using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Colorado.Models
{
    public class HttpAnalyzerData
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [DisplayName("Source IP")]
        public string SourceIp { get; set; }

        [Required]
        [DisplayName("Destination IP")]
        public string DestinationIp { get; set; }

        [Required]
        [DisplayName("HTTP method")]
        public string Method { get; set; }

        [Required]
        [DisplayName("Quantity (B)")]
        public int Quantity { get; set; }
    }
}
