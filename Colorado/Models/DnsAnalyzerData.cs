using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Colorado.Models
{
    public class DnsAnalyzerData
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [DisplayName("Source IP")]
        public string SrcIp { get; set; }

        [Required]
        [DisplayName("Destination IP")]
        public string DstIp { get; set; }

        [DisplayName("Source port")]
        public string SrcPort { get; set; }

        [DisplayName("Destination port")]
        public string DstPort { get; set; }

        [Required]
        [DisplayName("Domain Name")]
        public string DomainName { get; set; }

        public virtual ICollection<DnsResponseAddress> ResponseAddresses { get; set; }
    }

    public class DnsResponseAddress
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string IpAddress { get; set; }

        [ForeignKey("AnalyzerData")]
        public int DnsAnalyzerDataId { get; set; }
        public virtual DnsAnalyzerData AnalyzerData { get; set; }

    }
}
