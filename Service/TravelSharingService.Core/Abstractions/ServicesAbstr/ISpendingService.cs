public interface ISpendingService
{
    Task<List<SpendingEntity>> GetByTripId(Guid tripId);
    Task<SpendingEntity?> GetById(Guid spendingId);
    Task Add(Guid id, Guid tripId, Guid createdByUserId, SpendingCategory category, string currency, decimal amount, string name, List<SpendingPaymentEntity> payments, List<SpendingShareEntity> shares);
    Task Update(Guid id, Guid tripId, Guid createdByUserId, SpendingCategory category, string currency, decimal amount, string name, List<SpendingPaymentEntity> payments, List<SpendingShareEntity> shares);
    Task Delete(Guid spendingId);
}
