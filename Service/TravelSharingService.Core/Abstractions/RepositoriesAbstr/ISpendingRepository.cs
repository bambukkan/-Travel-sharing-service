public interface ISpendingRepository
{
    Task<List<SpendingEntity>> GetByTripId(Guid tripId);
    Task<SpendingEntity?> GetById(Guid spendingId);
    Task Add(SpendingEntity spending);
    Task Update(SpendingEntity spending);
    Task Delete(Guid spendingId);
}

