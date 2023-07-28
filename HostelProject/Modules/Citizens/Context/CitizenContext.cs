using HostelProject.Modules.Hostels.Entity;
using HostelProject.Modules.Hostels.Mapping;
using Microsoft.EntityFrameworkCore;
using ProjectApi.Modules.Entity;
using ProjectApi.Modules.Mapping;
using vedaproject.vedaproject.Entity;
using vedaproject.vedaproject.Mappings;

namespace ProjectApi.Modules.Context
{
    public class CitizenContext:DbContext
    {

        public CitizenContext(DbContextOptions<CitizenContext> options) : base(options) 
        {

        }
        public DbSet<CitizenEntity> citizenEntities { get; set; }
        public DbSet<DocumentEntity> documentEntities { get; set; }
        public DbSet<HostelEntity> hostelEntities { get; set; }
        public DbSet<RoomsEntity> RoomsEntities { get; set; }
        public DbSet<StaffEntity> StaffEntities { get; set; }
        public DbSet<HostelStaffEntity> hostelstaff { get; set; }
       

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CitizenMapping());
            modelBuilder.ApplyConfiguration(new DocumentMapping());
            modelBuilder.ApplyConfiguration(new HostelMapping());
            modelBuilder.ApplyConfiguration(new RoomsMapping());
            modelBuilder.ApplyConfiguration(new StaffMappings());
            modelBuilder.ApplyConfiguration(new HostelStaffMappings());
            
        }
    }
}
