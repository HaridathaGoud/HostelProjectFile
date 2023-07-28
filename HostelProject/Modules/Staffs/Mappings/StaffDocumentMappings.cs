using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using vedaproject.vedaproject.Entity;

namespace vedaproject.vedaproject.Mappings
{
    public class StaffDocumentMappings : IEntityTypeConfiguration<StaffDocumentEntity>
    {
        public void Configure(EntityTypeBuilder<StaffDocumentEntity> builder)
        {
            builder.ToTable("StaffDocument", "Hms");
            builder.Property(x => x.Id);
            builder.Property(x => x.StaffId);
            builder.Property(x => x.Avatar);

            builder.HasOne(x => x.staffDoc)
                  .WithMany(x => x.stafff)
                  .HasForeignKey(x => x.StaffId);
        }
    }
}
