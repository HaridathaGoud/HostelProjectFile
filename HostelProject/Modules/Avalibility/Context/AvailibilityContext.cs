using HostelProject.Modules.Avalibility.Entity;
using HostelProject.Modules.Avalibility.Mapping;
using Microsoft.EntityFrameworkCore;
using Veda_Project_Sample.Entity;
using Veda_Project_Sample.Mapping;

namespace Veda_Project_Sample.Context
{
    public class AvailibilityContext : DbContext
    {
        public AvailibilityContext(DbContextOptions<AvailibilityContext> options) : base(options) { }

        public DbSet<HostelEntity> hostelEntities { get; set; }
        public DbSet<RoomsEntity> roomsEntities { get; set; }
        public DbSet<FacilityEntity> facilityEntities { get; set; }
        public DbSet<HostelStaffEntity> hostelStaffEntities { get; set; }
        public DbSet<HostelRoomFacilityEntity> hostelRoomFacilityEntities { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new HostelMapping());
            modelBuilder.ApplyConfiguration(new RoomsMapping());
            modelBuilder.ApplyConfiguration(new FacilityMapping());
            modelBuilder.ApplyConfiguration(new HostelStaffMapping());
            modelBuilder.ApplyConfiguration(new HostelRoomFacilityMapping());

        }
    }
    }
    

