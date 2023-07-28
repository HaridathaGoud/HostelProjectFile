
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectApi.Modules.Entity;

namespace ProjectApi.Modules.Mapping
{
    public class DocumentMapping : IEntityTypeConfiguration<DocumentEntity>
    {      
        public void Configure(EntityTypeBuilder<DocumentEntity> builder)
        {
            builder.ToTable("CityzensDocument", "Hms");
            builder.Property(x => x.Id);
            builder.Property(x => x.CitizenId);
            builder.Property(x => x.ImageUrl);
        }

    }
}
