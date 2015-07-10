using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Colorado.Models
{
    public class AccessList
    {
        public enum Action
        {
            Permit,
            Deny
        }

        [Key]
        public int id { get; set; }

        [Required]
        [DisplayName("Number")]
        public int number { get; set; }

        [Required]
        [DisplayName("Action")]
        public Action action { get; set; }

        [Required]
        [DisplayName("L3 Protocol")]
        public string protocol { get; set; }

        [DisplayName("TTL")]
        [Range(0, int.MaxValue)]
        public int? ttl { get; set; }

        [ForeignKey("IpSource")]
        [DisplayName("Source IP")]
        public int ip_source { get; set; }
        public IpNetwork IpSource { get; set; }

        [ForeignKey("IpDestination")]
        [DisplayName("Destination IP")]
        public int ip_destination { get; set; }
        public IpNetwork IpDestination { get; set; }

        [ForeignKey("PortSource")]
        [DisplayName("Source Port")]
        public int pn_source { get; set; }
        public Port PortSource { get; set; }

        [ForeignKey("PortDestination")]
        [DisplayName("Destination Port")]
        public int pn_destination { get; set; }
        public Port PortDestination { get; set; }

        [ForeignKey("Filter")]
        [DisplayName("Filter")]
        public int filter_id { get; set; }
        public Filter Filter { get; set; }
    }
}
