using HostelProject.Modules.Maintenance.MaintenanceEntity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace HostelProject.Modules.Maintenance.MaintenanceMapping
{
    public class MaintanMapping : IEntityTypeConfiguration<MaintanEntity>
    {
        public void Configure(EntityTypeBuilder<MaintanEntity> builder)
        {
            builder.ToTable("Maintenance", "Hms");
            builder.Property(x => x.Id);
            builder.Property(x => x.HostelId);
            builder.Property(x => x.Date);
            builder.Property(x => x.MaintenanceType);
            builder.Property(x => x.Remarks);
            builder.Property(x => x.Amount);
            builder.Property(x => x.StaffId);
            builder.Property(x => x.Staff);
            builder.Property(x => x.ModifiedDate);
            builder.Property(x => x.ModifiedBy);
            builder.Property(x => x.CreatedDate);
            builder.Property(x => x.CreatedBy);
            builder.Property(x => x.Document);
           // builder.Property(x => x.status);

            builder.HasMany(p => p.DocumentEntities)
           .WithOne(b => b.MaintanEntity)
           .HasForeignKey(b => b.MaintenanceId);
        }
    }
}
