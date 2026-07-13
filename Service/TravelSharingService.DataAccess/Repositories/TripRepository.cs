using Microsoft.EntityFrameworkCore;

public class TripRepository(TravelSharingDbContext context) : ITripRepository
{
    public Task<List<TripEntity>> GetByUserId(Guid userId)
    {
        return context.Trips
            .AsNoTracking()
            .Where(t => t.Participants.Any(p => p.UserId == userId))
            .Include(t => t.TripLocations)
            .Include(t => t.Participants)
                .ThenInclude(p => p.User)
            .ToListAsync();
    }

    public Task<TripEntity?> GetById(Guid tripId)
    {
        return context.Trips
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
        return context.TripParticipants
            .AsNoTracking()
            .Where(p => p.TripId == tripId)
            .Select(p => p.User!)
            .ToListAsync();
    }

    public async Task Add(TripEntity trip)
    {
        await context.Trips.AddAsync(trip);
        await context.SaveChangesAsync();
    }

    public async Task Update(TripEntity trip)
    {
        context.Trips.Update(trip);
        await context.SaveChangesAsync();
    }

    public async Task Delete(Guid tripId)
    {
        var trip = await context.Trips.FirstOrDefaultAsync(t => t.Id == tripId);
        if (trip is null)
        {
            return;
        }

        context.Trips.Remove(trip);
        await context.SaveChangesAsync();
    }
}


