using HostelProject.Modules.FeeDetails.FeeEntity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HostelProject.Modules.FeeDetails.FeeMapping
{
    public class FeeMappings : IEntityTypeConfiguration<FeeEntitys>
    {
        public void Configure(EntityTypeBuilder<FeeEntitys> builder)
        {
            builder.ToTable("FeeDetails", "Hms");
            builder.Property(x => x.Id);
            builder.Property(x => x.TransactionId);
            builder.Property(x => x.HostelId);
            builder.Property(x => x.RoomId);
            builder.Property(x => x.CitizenId);
            builder.Property(x => x.Fee);
            builder.Property(x => x.FromDate);
            builder.Property(x => x.ToDate);
            builder.Property(x => x.PaymentType);
            builder.Property(x => x.Other);
            builder.Property(x => x.CreatedBy);
            builder.Property(x => x.CreatedDate);
        }
    }
}
