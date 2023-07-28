using HostelProject.Modules.Hostels.Entity;
using HostelProject.Modules.Hostels.Mapping;
using Microsoft.EntityFrameworkCore;
using vedaproject.vedaproject.Entity;
using vedaproject.vedaproject.Mappings;

namespace HostelProject.Modules.Hostels.Context
{
    public class HostelsContex : DbContext
    {
        public HostelsContex(DbContextOptions<HostelsContex> options) : base(options)
        {
        }
        public DbSet<HostelEntity> HostelEntities { get; set; }
        public DbSet<RoomsEntity> RoomsEntities { get; set; }
        public DbSet<FacilitiesEntity> FacilityEntities { get; set; }
        public DbSet<HostelRoomFacilityEntity> hostelRoomFacilities { get; set; }
        public DbSet<HostelStaffEntity> hostelStaff {  get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new HostelMapping());
            modelBuilder.ApplyConfiguration(new RoomsMapping());
            modelBuilder.ApplyConfiguration(new FacilitiesMapping());
            modelBuilder.ApplyConfiguration(new HostelRoomFacilityMapping());
            modelBuilder.ApplyConfiguration(new HostelStaffMappings());
        }
    }
}
