

using Microsoft.EntityFrameworkCore;

public class TravelSharingDbContext(DbContextOptions<TravelSharingDbContext> options): DbContext(options)
{
    public DbSet<SpendingEntity> Spendings {get;set;}
    public DbSet<TripEntity> Trips {get;set;}
    public DbSet<UserEntity>Users{get;set;}
    public DbSet<TripLocation> TripLocations { get; set; }
    public DbSet<TripParticipantEntity> TripParticipants { get; set; }
    public DbSet<SpendingPaymentEntity> SpendingPayments { get; set; }
    public DbSet<SpendingShareEntity> SpendingShares { get; set; }
    protected  override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new SpendingConfiguration());
        modelBuilder.ApplyConfiguration(new TripConfiguration());
        modelBuilder.ApplyConfiguration(new UserConfiguration());
        base.OnModelCreating(modelBuilder);
    }
}