
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Veda_Project_Sample.Entity;

namespace Veda_Project_Sample.Mapping
{
    public class FacilityMapping :IEntityTypeConfiguration<FacilityEntity>
    {
        public void Configure(EntityTypeBuilder<FacilityEntity> builder)
        {
            builder.ToTable("Facilities", "Hms");
            builder.Property(x => x.Id);
            builder.Property(x => x.RoomId);
            builder.Property(x => x.Facility);

            builder.HasOne(x => x.hostelroomfacilityentity).WithMany(x => x.facilityEntities).HasForeignKey(x => x.Id);

        }

       
    }
}
