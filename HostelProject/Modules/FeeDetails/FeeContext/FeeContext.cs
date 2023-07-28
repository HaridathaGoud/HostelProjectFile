
using HostelProject.Modules.FeeDetails.FeeEntity;
using HostelProject.Modules.FeeDetails.FeeMapping;
using HostelProject.Modules.Hostels.Entity;
using HostelProject.Modules.Hostels.Mapping;
using Microsoft.EntityFrameworkCore;
using ProjectApi.Modules.Entity;
using ProjectApi.Modules.Mapping;
using Veda_Project_Sample.Entity;
using vedaproject.vedaproject.Entity;
using vedaproject.vedaproject.Mappings;
using HostelEntity = HostelProject.Modules.Hostels.Entity.HostelEntity;
using RoomsEntity = HostelProject.Modules.Hostels.Entity.RoomsEntity;

namespace HostelProject.Modules.FeeDetails.FeeContext
{
    public class FeeContexts:DbContext
    {
        public FeeContexts(DbContextOptions<FeeContexts>options):base(options) { } 
        
        public DbSet<FeeEntitys> feeEntities { get; set; }
        public DbSet<HostelEntity> hostelEntities { get; set;}
        public DbSet<RoomsEntity> roomsEntities { get; set; }
        public DbSet<CitizenEntity> citizenEntities { get; set; }
        public DbSet<HostelStaffEntity> hostelStaffEntities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new FeeMappings());
            modelBuilder.ApplyConfiguration(new HostelMapping());
            modelBuilder.ApplyConfiguration(new RoomsMapping());
            modelBuilder.ApplyConfiguration(new CitizenMapping());
            modelBuilder.ApplyConfiguration(new HostelStaffMappings());
        }

    }
}
