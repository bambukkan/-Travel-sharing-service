
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class UserConfiguration() : IEntityTypeConfiguration<UserEntity>
{
    public void Configure(EntityTypeBuilder<UserEntity> builder)
    {
        builder.HasKey(u => u.Id);

        builder.HasMany(u => u.TripParticipants)
            .WithOne(u => u.User).HasForeignKey(u => u.UserId);
        builder.HasMany(u => u.CreatedSpendings)
            .WithOne(u => u.CreatedByUser).HasForeignKey(u => u.CreatedByUserId);
    }
}