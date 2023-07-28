using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;
using Veda_Project_Sample.Entity;
using Veda_Project_Sample.Mapping;
using vedaproject.vedaproject.Entity;
using vedaproject.vedaproject.Mappings;

namespace vedaproject.vedaproject.Context
{
    public class StaffContext:DbContext
    {
        public StaffContext(DbContextOptions<StaffContext>options):base(options) 
        {
          
        }
        public DbSet<StaffEntity> Projects { get; set; }
        public DbSet<HostelStaffEntity> Staffs { get; set; }

        public DbSet<StaffDocumentEntity> docu { get; set; }
        public DbSet<HostelEntity> Hostel { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new StaffMappings());
            modelBuilder.ApplyConfiguration(new HostelStaffMappings());
            modelBuilder.ApplyConfiguration(new StaffDocumentMappings());
            modelBuilder.ApplyConfiguration(new HostelMapping());
        }

    }
}
