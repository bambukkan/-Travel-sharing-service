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

    public Task Add(Guid id, Guid tripId, Guid createdByUserId, SpendingCategory category, string currency, decimal amount, string name, List<SpendingPaymentEntity> payments, List<SpendingShareEntity> shares)
    {
        var spendingEntity = new SpendingEntity
        {
            Id = id,
            TripId = tripId,
            CreatedByUserId = createdByUserId,
            Category = category,
            Currency = currency,
            Amount = amount,
            Name = name,
            Payments = payments,
            Shares = shares
        };

        return spendingRepository.Add(spendingEntity);
    }

    public Task Update(Guid id, Guid tripId, Guid createdByUserId, SpendingCategory category, string currency, decimal amount, string name, List<SpendingPaymentEntity> payments, List<SpendingShareEntity> shares)
    {
        var spendingEntity = new SpendingEntity
        {
            Id = id,
            TripId = tripId,
            CreatedByUserId = createdByUserId,
            Category = category,
            Currency = currency,
            Amount = amount,
            Name = name,
            Payments = payments,
            Shares = shares
        };

        return spendingRepository.Update(spendingEntity);
    }

    public Task Delete(Guid spendingId)
    {
        return spendingRepository.Delete(spendingId);
    }
}
