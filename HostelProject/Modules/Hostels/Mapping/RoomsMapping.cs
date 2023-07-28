using HostelProject.Modules.Hostels.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HostelProject.Modules.Hostels.Mapping
{
    public class RoomsMapping : IEntityTypeConfiguration<RoomsEntity>
    {
        public void Configure(EntityTypeBuilder<RoomsEntity> builder)
        {
            builder.ToTable("Rooms", "Hms");
            builder.Property(x => x.Id);
            builder.Property(x => x.HostelId);
            builder.Property(x => x.RoomNumber);
            builder.Property(x => x.Floor);
            builder.Property(x => x.BedsCount);
            builder.Property(x => x.AvailabilityBedsCount);
            builder.Property(x => x.Fee);
            builder.Property(x => x.ModifiedBy);
            builder.Property(x => x.ModifiedDate);
            builder.Property(x => x.CreatedBy);
            builder.Property(x => x.CreatedDate);
            builder.Property(x => x.status);

           builder.HasOne(x=>x.Hostels)
                .WithMany(x=>x.Rooms)
                .HasForeignKey(x=>x.HostelId);

           
        }
    }
}
