using Microsoft.EntityFrameworkCore;

public class SpendingRepository(TravelSharingDbContext context) : ISpendingRepository
{
    public Task<List<SpendingEntity>> GetByTripId(Guid tripId)
    {
        return context.Spendings
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
        return context.Spendings
            .Include(s => s.CreatedByUser)
            .Include(s => s.Payments)
                .ThenInclude(p => p.User)
            .Include(s => s.Shares)
                .ThenInclude(sh => sh.User)
            .FirstOrDefaultAsync(s => s.Id == spendingId);
    }

    public async Task Add(SpendingEntity spending)
    {
        await context.Spendings.AddAsync(spending);
        await context.SaveChangesAsync();
    }

    public async Task Update(SpendingEntity spending)
    {
        context.Spendings.Update(spending);
        await context.SaveChangesAsync();
    }

    public async Task Delete(Guid spendingId)
    {
        var spending = await context.Spendings.FirstOrDefaultAsync(s => s.Id == spendingId);
        if (spending is null)
        {
            return;
        }

        context.Spendings.Remove(spending);
        await context.SaveChangesAsync();
    }
}


