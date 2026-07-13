
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class SpendingConfiguration() : IEntityTypeConfiguration<SpendingEntity>
{
    public void Configure(EntityTypeBuilder<SpendingEntity> builder)
    {
        builder.HasKey(u => u.Id);

        builder.HasMany(s => s.Payments)
            .WithOne(s => s.Spending).HasForeignKey(s => s.SpendingId);
        builder.HasMany(s => s.Shares)
            .WithOne(s => s.Spending).HasForeignKey(s => s.SpendingId);
    }
}