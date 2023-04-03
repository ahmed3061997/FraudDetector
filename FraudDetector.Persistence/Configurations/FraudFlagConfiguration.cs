using FraudDetector.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FraudDetector.Persistence.Configurations
{
    internal sealed class FraudFlagConfiguration : IEntityTypeConfiguration<FraudFlag>
    {
        public void Configure(EntityTypeBuilder<FraudFlag> builder)
        {
            builder.ToTable(nameof(FraudFlag));
            builder.HasKey(entity => entity.Id);
        }
    }
}
