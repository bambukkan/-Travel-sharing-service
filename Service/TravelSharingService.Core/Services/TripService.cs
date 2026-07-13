public class TripService(ITripRepository tripRepository) : ITripService
{
    public Task<List<TripEntity>> GetByUserId(Guid userId)
    {
        return tripRepository.GetByUserId(userId);
    }

    public Task<TripEntity?> GetById(Guid tripId)
    {
        return tripRepository.GetById(tripId);
    }

    public Task<List<UserEntity>> GetUsersByTripId(Guid tripId)
    {
        return tripRepository.GetUsersByTripId(tripId);
    }

    public Task Add(TripEntity trip)
    {
        return tripRepository.Add(trip);
    }

    public Task Update(TripEntity trip)
    {
        return tripRepository.Update(trip);
    }

    public Task Delete(Guid tripId)
    {
        return tripRepository.Delete(tripId);
    }
}
