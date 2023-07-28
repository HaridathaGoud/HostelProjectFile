using HostelProject.Modules.Hostels.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HostelProject.Modules.Hostels.Mapping
{
    public class HostelMapping : IEntityTypeConfiguration<HostelEntity>
    {
        public void Configure(EntityTypeBuilder<HostelEntity> builder)
        {
            builder.ToTable("Hostels", "Hms");
            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.HostelName);
            builder.Property(x => x.Email);
            builder.Property(x => x.ContactNumber);
            builder.Property(x => x.Location);
            builder.Property(x => x.Address);
            builder.Property(x => x.Avatar);
            builder.Property(x => x.HostelRegNumber);
            builder.Property(x => x.ModifiedBy);
            builder.Property(x => x.ModifiedDate);
            builder.Property(x => x.CreatedBy);
            builder.Property(x => x.CreatedDate);
            builder.Property(x => x.status);

            
        }
    }
}
