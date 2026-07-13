public interface ITripService
{
    Task<List<TripEntity>> GetByUserId(Guid userId);
    Task<TripEntity?> GetById(Guid tripId);
    Task<List<UserEntity>> GetUsersByTripId(Guid tripId);
    Task Add(TripEntity trip);
    Task Update(TripEntity trip);
    Task Delete(Guid tripId);
}
