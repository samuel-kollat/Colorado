using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Colorado.Models
{
    class DnsAnalyzerData
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string SrcIp { get; set; }

        [Required]
        public string DstIp { get; set; }

        public string SrcPort { get; set; }
        public string DstPort { get; set; }

        [Required]
        public string DomainName { get; set; }

        public ICollection<DnsResponseAddress> ResponseAddresses { get; set; }
    }

    class DnsResponseAddress
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string IpAddress { get; set; }

        [ForeignKey("AnalyzerData")]
        public int DnsAnalyzerDataId { get; set; }
        public DnsAnalyzerData AnalyzerData { get; set; }

    }
}
