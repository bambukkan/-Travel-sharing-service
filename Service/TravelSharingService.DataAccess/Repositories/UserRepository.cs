using Microsoft.EntityFrameworkCore;

public class UserRepository(TravelSharingDbContext context) : IUserRepository
{
    public Task<List<UserEntity>> GetAll()
    {
        return context.Users
            .AsNoTracking()
            .ToListAsync();
    }

    public Task<UserEntity?> GetById(Guid userId)
    {
        return context.Users
            .Include(u => u.TripParticipants)
            .FirstOrDefaultAsync(u => u.Id == userId);
    }

    public Task<UserEntity?> GetByEmail(string email)
    {
        return context.Users
            .AsNoTracking()
            .FirstOrDefaultAsync(u => u.Email == email);
    }

    public Task<List<UserEntity>> GetByTripId(Guid tripId)
    {
        return context.TripParticipants
            .AsNoTracking()
            .Where(p => p.TripId == tripId)
            .Select(p => p.User!)
            .ToListAsync();
    }

    public async Task Add(UserEntity user)
    {
        await context.Users.AddAsync(user);
        await context.SaveChangesAsync();
    }

    public async Task Update(UserEntity user)
    {
        context.Users.Update(user);
        await context.SaveChangesAsync();
    }

    public async Task Delete(Guid userId)
    {
        var user = await context.Users.FirstOrDefaultAsync(u => u.Id == userId);
        if (user is null)
        {
            return;
        }

        context.Users.Remove(user);
        await context.SaveChangesAsync();
    }
}


