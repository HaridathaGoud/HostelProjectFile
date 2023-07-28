using HostelProject.Modules.Avalibility.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HostelProject.Modules.Avalibility.Mapping
{
    public class HostelStaffMapping : IEntityTypeConfiguration<HostelStaffEntity>
    {
        public void Configure(EntityTypeBuilder<HostelStaffEntity> builder)
        {
            builder.ToTable("HostelStaff", "Hms");
            builder.Property(x => x.Id);
            builder.Property(x => x.HstId);
            builder.Property(x => x.StaffId);
            builder.HasOne(x => x.facilityentity).WithMany(x => x.hostelstaffentity).HasForeignKey(x => x.HstId);
        }
    }
}
