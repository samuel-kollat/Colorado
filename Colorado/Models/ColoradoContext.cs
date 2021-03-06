﻿using System.Data.Entity;

namespace Colorado.Models
{
    public class ColoradoContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx

        public ColoradoContext()
            : base("name=Sec6NetMySqlServer")
        {
        }

        public DbSet<Analyzer> Analyzers { get; set; }
        public DbSet<Certificate> Certificates { get; set; }
        public DbSet<Application> Applications { get; set; }
        public DbSet<NbarProtocol> NbarProtocols { get; set; }
        public DbSet<Router> Routers { get; set; }
        public DbSet<Port> Ports { get; set; }
        public DbSet<Filter> Filters { get; set; }
        public DbSet<IpNetwork> IpNetworks { get; set; }
        public DbSet<AccessList> AccessLists { get; set; }
        public DbSet<FilterHasNbarProtocol> FilterHasNbarProtocols { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<FilterHasNbarProtocol>().HasKey(t => new { t.filter_id, t.nbar_protocol_id });
        }
    }
}
