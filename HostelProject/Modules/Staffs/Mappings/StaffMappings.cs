using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Hosting;
using vedaproject.vedaproject.Entity;

namespace vedaproject.vedaproject.Mappings
{
    public class StaffMappings : IEntityTypeConfiguration<StaffEntity>
    {
        public void Configure(EntityTypeBuilder<StaffEntity> builder)
        {
            builder.ToTable("Staff","Hms");
            builder.Property(x => x.Id);
            builder.Property(x => x.HostelId);
            builder.Property(x => x.StaffName);
            builder.Property(x => x.MobileNo);
            builder.Property(x => x.Address);
            builder.Property(x => x.IdProof);
            builder.Property(x => x.Salary);
            builder.Property(x => x.Designation);
            builder.Property(x => x.ModifiedDate);
            builder.Property(x => x.ModifiedBy);
            builder.Property(x => x.CreatedDate);
            builder.Property(x => x.CreatedBy);
            builder.Property(x => x.Status);

            builder.HasMany(x => x.HostelStaff)
               .WithOne(x => x.Staff)
               .HasForeignKey(x => x.StaffId);


        }
    }
}
