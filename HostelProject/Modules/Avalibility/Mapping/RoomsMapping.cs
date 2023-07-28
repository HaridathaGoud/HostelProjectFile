using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Veda_Project_Sample.Entity;

namespace Veda_Project_Sample.Mapping
{
    public class RoomsMapping : IEntityTypeConfiguration<RoomsEntity>
    {
        public void Configure(EntityTypeBuilder<RoomsEntity> builder)
        {
            builder.ToTable("Rooms", "Hms");
            builder.Property(x => x.Id);
            builder.Property(x => x.HostelId);
            builder.Property(x => x.RoomNumber);
            builder.Property(x => x.AvailabilityBedsCount);
            builder.Property(x => x.Fee);
            builder.Property(x => x.ModifiedBy);
            builder.Property(x => x.ModifiedDate);
            builder.Property(x => x.CreatedBy);
            builder.Property(x => x.CreatedDate);
            builder.Property(x => x.Status);

            builder.HasOne(x => x.hostelentity).WithMany(x => x.roomsEntities).HasForeignKey(x => x.HostelId);
        }
    }
}
