using HostelProject.Modules.Maintenance.MaintenanceEntity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace HostelProject.Modules.Maintenance.MaintenanceMapping
{
    public class MaintanDocumentMapping : IEntityTypeConfiguration<MaintanDocumentEntity>
    {
        public void Configure(EntityTypeBuilder<MaintanDocumentEntity> builder)
        {
            builder.ToTable("DocumentTable", "Hms");
            builder.Property(x => x.Id);
            builder.Property(x => x.MaintenanceId);
            builder.Property(x => x.Document);
        }
    }
}
