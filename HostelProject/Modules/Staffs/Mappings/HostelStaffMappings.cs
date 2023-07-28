using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using vedaproject.vedaproject.Entity;

namespace vedaproject.vedaproject.Mappings
{
    public class HostelStaffMappings : IEntityTypeConfiguration<HostelStaffEntity>
    {
        public void Configure(EntityTypeBuilder<HostelStaffEntity> builder)
        {
            builder.ToTable("HostelStaff", "Hms");
            builder.Property(x => x.Id);
            builder.Property(x => x.HstId);
            builder.Property(x => x.StaffId);

         

        }
    }
}
