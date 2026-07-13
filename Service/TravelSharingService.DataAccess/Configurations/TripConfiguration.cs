
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class TripConfiguration() : IEntityTypeConfiguration<TripEntity>
{
    public void Configure(EntityTypeBuilder<TripEntity> builder)
    {
        builder.HasKey(u => u.Id);

        builder.HasMany(t => t.TripLocations)
            .WithOne(t => t.Trip).HasForeignKey(t => t.TripId);

        builder.HasMany(t => t.Participants)
            .WithOne(t => t.Trip).HasForeignKey(t => t.TripId);

        builder.HasMany(t => t.Spendings)
            .WithOne(t => t.Trip).HasForeignKey(t => t.TripId);
    }
}