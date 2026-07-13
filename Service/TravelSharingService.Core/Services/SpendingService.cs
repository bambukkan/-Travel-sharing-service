public class SpendingService(ISpendingRepository spendingRepository) : ISpendingService
{
    public Task<List<SpendingEntity>> GetByTripId(Guid tripId)
    {
        return spendingRepository.GetByTripId(tripId);
    }

    public Task<SpendingEntity?> GetById(Guid spendingId)
    {
        return spendingRepository.GetById(spendingId);
    }

    public Task Add(SpendingEntity spending)
    {
        return spendingRepository.Add(spending);
    }

    public Task Update(SpendingEntity spending)
    {
        return spendingRepository.Update(spending);
    }

    public Task Delete(Guid spendingId)
    {
        return spendingRepository.Delete(spendingId);
    }
}
