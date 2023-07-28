using HostelProject.Modules.Avalibility.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HostelProject.Modules.Avalibility.Mapping
{
    public class HostelRoomFacilityMapping : IEntityTypeConfiguration<HostelRoomFacilityEntity>
    {
        public void Configure(EntityTypeBuilder<HostelRoomFacilityEntity> builder)
        {

            builder.ToTable("HostelRoomFacility", "Hms");
            builder.Property(x => x.Id);
            builder.Property(x => x.RoomId);
            builder.Property(x => x.FacilityId);
            builder.HasOne(x => x.roomsentity).WithMany(x => x.hostelRoomFacilityEntities).HasForeignKey(x => x.RoomId);
        }
    }
}
