using System.Data.Entity;

namespace Colorado.Models
{
    class ColoradoDashboardsContext : DbContext
    {
        public ColoradoDashboardsContext()
            : base("name=Sec6NetDashboardsMySqlServer")
        {
        }

        public DbSet<Dashboard> Dashboards { get; set; }
        public DbSet<DnsAnalyzerData> DnsAnalyzerDatas { get; set; }
        public DbSet<DnsResponseAddress> DnsResponseAddresses { get; set; }
        public DbSet<DnsTrackedDomain> DnsTrackedDomains { get; set; }
    }
}
