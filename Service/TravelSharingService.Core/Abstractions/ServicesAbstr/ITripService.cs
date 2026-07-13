public interface ITripService
{
    Task<List<TripEntity>> GetByUserId(Guid userId);
    Task<TripEntity?> GetById(Guid tripId);
    Task<List<UserEntity>> GetUsersByTripId(Guid tripId);
    Task Add(Guid id, string name, DateTime startTime, DateTime endTime, List<TripLocation> tripLocations, List<TripParticipantEntity> participants, decimal overallBudget);
    Task Update(Guid id, string name, DateTime startTime, DateTime endTime, List<TripLocation> tripLocations, List<TripParticipantEntity> participants, decimal overallBudget, List<SpendingEntity> spendings);
    Task Delete(Guid tripId);
}
