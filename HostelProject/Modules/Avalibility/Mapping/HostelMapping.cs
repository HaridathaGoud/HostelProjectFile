
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Veda_Project_Sample.Entity;

namespace Veda_Project_Sample.Mapping
{
    public class HostelMapping :IEntityTypeConfiguration<HostelEntity>
    {
        public void Configure(EntityTypeBuilder<HostelEntity> builder)
        {
            builder.ToTable("Hostels", "Hms");
            builder.Property(x => x.Id);
            builder.Property(x => x.HostelName);
            builder.Property(x => x.Status);
        }

        
    }
}
