
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectApi.Modules.Entity;

namespace ProjectApi.Modules.Mapping
{
    public class CitizenMapping : IEntityTypeConfiguration<CitizenEntity>
    { 
        public void Configure(EntityTypeBuilder<CitizenEntity> builder)
        {
            builder.ToTable("Citizens", "Hms");
            builder.Property(x => x.Id);
            builder.Property(x => x.HostelId);
            builder.Property(x => x.RoomId);
            builder.Property(x => x.CitizenName);
            builder.Property(x => x.Email);
            builder.Property(x => x.MobileNumber);
            builder.Property(x => x.AlternateNumber);
            builder.Property(x => x.Address);
            builder.Property(x => x.Guardian);
            builder.Property(x => x.GuardianNumber);
            builder.Property(x => x.IdProof);
            builder.Property(x => x.JoinDate);
            builder.Property(x => x.ModifeidBy);
            builder.Property(x => x.ModifiedDate);
            builder.Property(x => x.CreatedBy);
            builder.Property(x => x.CreatedDate);
            builder.Property(x => x.status);

            builder.HasMany(s => s.DocEntity)
                .WithOne(x => x.Tenate)
                .HasForeignKey(x => x.CitizenId);
        }

    }
}
