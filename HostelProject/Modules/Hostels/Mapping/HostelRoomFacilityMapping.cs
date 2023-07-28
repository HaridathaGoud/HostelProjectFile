using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using HostelProject.Modules.Hostels.Entity;

namespace HostelProject.Modules.Hostels.Mapping
{
    public class HostelRoomFacilityMapping : IEntityTypeConfiguration<HostelRoomFacilityEntity>
    {
        public void Configure(EntityTypeBuilder<HostelRoomFacilityEntity> builder)
        {
            builder.ToTable("HostelRoomFacility", "Hms");
            builder.Property(x => x.Id);
            builder.Property(x => x.RoomId);
            builder.Property(x => x.FacilityId);

           
            builder.HasOne(x=>x.Rms)
                   .WithMany(x=>x.HstlFacility)
                   .HasForeignKey(x=>x.RoomId);

            builder.HasOne(x => x.FacilitiesEntity)
               .WithMany(x => x.HostelRoomFacilities)
               .HasForeignKey(x => x.FacilityId);


        }
    }
}
