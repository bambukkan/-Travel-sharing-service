using Microsoft.EntityFrameworkCore;

public class UserRepository(TravelSharingDbContext dbContext) : IUserRepository
{
    public Task<List<UserEntity>> GetAll()
    {
        return dbContext.Users
            .AsNoTracking()
            .ToListAsync();
    }

    public Task<UserEntity?> GetById(Guid userId)
    {
        return dbContext.Users
            .Include(u => u.TripParticipants)
            .FirstOrDefaultAsync(u => u.Id == userId);
    }

    public Task<UserEntity?> GetByEmail(string email)
    {
        return dbContext.Users
            .AsNoTracking()
            .FirstOrDefaultAsync(u => u.Email == email);
    }

    public Task<List<UserEntity>> GetByTripId(Guid tripId)
    {
        return dbContext.TripParticipants
            .AsNoTracking()
            .Where(p => p.TripId == tripId)
            .Select(p => p.User!)
            .ToListAsync();
    }

    public async Task Add(UserEntity user)
    {
        await dbContext.Users.AddAsync(user);
        await dbContext.SaveChangesAsync();
    }

    public async Task Update(UserEntity user)
    {
        dbContext.Users.Update(user);
        await dbContext.SaveChangesAsync();
    }

    public async Task Delete(Guid userId)
    {
        var user = await dbContext.Users.FirstOrDefaultAsync(u => u.Id == userId);
        if (user is null)
        {
            return;
        }

        dbContext.Users.Remove(user);
        await dbContext.SaveChangesAsync();
    }
}


