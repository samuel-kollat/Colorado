using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

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
        [DisplayName("IP Address")]
        public string IpAddress { get; set; }

        [ForeignKey("AnalyzerData")]
        public int DnsAnalyzerDataId { get; set; }
        public virtual DnsAnalyzerData AnalyzerData { get; set; }

    }

    public class DnsTrackedDomain
    {
        public enum Status
        {
            Success,
            Info,
            Warning,
            Error
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(255)]
        [RegularExpression("^(([a-zA-Z0-9-]+|\\*)\\.)+([a-zA-Z0-9-]+|\\*)$")]
        [DisplayName("Expression")]
        public string DomainExpression { get; set; }

        [Required]
        [DisplayName("Status")]
        public Status DomainStatus { get; set; }

    }
}
