using Colorado.Models;

namespace Colorado.ViewModels
{
    public class DnsLookUp
    {
        public DnsAnalyzerData Data { get; set; }
        public DnsTrackedDomain.Status? Status { get; set; }
        public string CssBgCollor { get; set; }
    }
}
