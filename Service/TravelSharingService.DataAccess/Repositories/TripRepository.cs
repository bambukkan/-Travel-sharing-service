using Microsoft.EntityFrameworkCore;

public class TripRepository(TravelSharingDbContext dbContext) : ITripRepository
{
    public Task<List<TripEntity>> GetByUserId(Guid userId)
    {
        return dbContext.Trips
            .AsNoTracking()
            .Where(t => t.Participants.Any(p => p.UserId == userId))
            .Include(t => t.TripLocations)
            .Include(t => t.Participants)
                .ThenInclude(p => p.User)
            .ToListAsync();
    }

    public Task<TripEntity?> GetById(Guid tripId)
    {
        return dbContext.Trips
            .Include(t => t.TripLocations)
            .Include(t => t.Participants)
                .ThenInclude(p => p.User)
            .Include(t => t.Spendings)
                .ThenInclude(s => s.Payments)
            .Include(t => t.Spendings)
                .ThenInclude(s => s.Shares)
            .FirstOrDefaultAsync(t => t.Id == tripId);
    }

    public Task<List<UserEntity>> GetUsersByTripId(Guid tripId)
    {
        return dbContext.TripParticipants
            .AsNoTracking()
            .Where(p => p.TripId == tripId)
            .Select(p => p.User!)
            .ToListAsync();
    }

    public async Task Add(TripEntity trip)
    {
        await dbContext.Trips.AddAsync(trip);
        await dbContext.SaveChangesAsync();
    }

    public async Task Update(TripEntity trip)
    {
        dbContext.Trips.Update(trip);
        await dbContext.SaveChangesAsync();
    }

    public async Task Delete(Guid tripId)
    {
        var trip = await dbContext.Trips.FirstOrDefaultAsync(t => t.Id == tripId);
        if (trip is null)
        {
            return;
        }

        dbContext.Trips.Remove(trip);
        await dbContext.SaveChangesAsync();
    }
}


