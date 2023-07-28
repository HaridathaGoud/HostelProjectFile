using HostelProject.Modules.Hostels.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HostelProject.Modules.Hostels.Mapping
{
    public class FacilitiesMapping : IEntityTypeConfiguration<FacilitiesEntity>
    {
        public void Configure(EntityTypeBuilder<FacilitiesEntity> builder)
        {
            builder.ToTable("Facilities", "Hms");
            builder.Property(x => x.Id);
            builder.Property(x => x.Facility);
            builder.Property(x => x.IsChecked);
            builder.Property(x => x.RecordStatus);
        }
    }
}
