using HostelProject.Modules.Hostels.Entity;
using HostelProject.Modules.Hostels.Mapping;
using HostelProject.Modules.Maintenance.MaintenanceEntity;
using HostelProject.Modules.Maintenance.MaintenanceMapping;
using Microsoft.EntityFrameworkCore;
using ProjectApi.Modules.Entity;
using vedaproject.vedaproject.Entity;
using vedaproject.vedaproject.Mappings;

namespace HostelProject.Modules.Maintenance.MaintananceContext
{
    public class MaintanContext : DbContext
    {
        public MaintanContext(DbContextOptions<MaintanContext> options) : base(options)
        {
        }

        public DbSet<MaintanEntity>? maintans { get; set; }
        public DbSet<MaintanDocumentEntity>? documents { get; set; }
        public DbSet<HostelEntity>? hostelEntities { get; set; }
        public DbSet<CitizenEntity>? citizenEntities { get; set; }
        public DbSet<HostelStaffEntity>? hostelStaffEntities { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new MaintanMapping());
            modelBuilder.ApplyConfiguration(new MaintanDocumentMapping());
            modelBuilder.ApplyConfiguration(new HostelMapping());
            modelBuilder.ApplyConfiguration(new HostelMapping());
            modelBuilder.ApplyConfiguration(new HostelStaffMappings());
        }

    }
}
