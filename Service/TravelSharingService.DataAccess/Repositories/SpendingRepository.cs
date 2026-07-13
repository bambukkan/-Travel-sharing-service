using Microsoft.EntityFrameworkCore;

public class SpendingRepository(TravelSharingDbContext dbContext) : ISpendingRepository
{
    public Task<List<SpendingEntity>> GetByTripId(Guid tripId)
    {
        return dbContext.Spendings
            .AsNoTracking()
            .Where(s => s.TripId == tripId)
            .Include(s => s.CreatedByUser)
            .Include(s => s.Payments)
                .ThenInclude(p => p.User)
            .Include(s => s.Shares)
                .ThenInclude(sh => sh.User)
            .ToListAsync();
    }

    public Task<SpendingEntity?> GetById(Guid spendingId)
    {
        return dbContext.Spendings
            .Include(s => s.CreatedByUser)
            .Include(s => s.Payments)
                .ThenInclude(p => p.User)
            .Include(s => s.Shares)
                .ThenInclude(sh => sh.User)
            .FirstOrDefaultAsync(s => s.Id == spendingId);
    }

    public async Task Add(SpendingEntity spending)
    {
        await dbContext.Spendings.AddAsync(spending);
        await dbContext.SaveChangesAsync();
    }

    public async Task Update(SpendingEntity spending)
    {
        dbContext.Spendings.Update(spending);
        await dbContext.SaveChangesAsync();
    }

    public async Task Delete(Guid spendingId)
    {
        var spending = await dbContext.Spendings.FirstOrDefaultAsync(s => s.Id == spendingId);
        if (spending is null)
        {
            return;
        }

        dbContext.Spendings.Remove(spending);
        await dbContext.SaveChangesAsync();
    }
}


