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

    public Task Add(Guid id, string name, DateTime startTime, DateTime endTime, List<TripLocation> tripLocations, List<TripParticipantEntity> participants, decimal overallBudget)
    {
        var tripEntity = new TripEntity
        {
            Id = id,
            Name = name,
            StartTime = startTime,
            EndTime = endTime,
            TripLocations = tripLocations,
            Participants = participants,
            OverallBudget = overallBudget
        };

        return tripRepository.Add(tripEntity);
    }

    public Task Update(Guid id, string name, DateTime startTime, DateTime endTime, List<TripLocation> tripLocations, List<TripParticipantEntity> participants, decimal overallBudget, List<SpendingEntity> spendings)
    {
        var tripEntity = new TripEntity
        {
            Id = id,
            Name = name,
            StartTime = startTime,
            EndTime = endTime,
            TripLocations = tripLocations,
            Participants = participants,
            OverallBudget = overallBudget,
            Spendings = spendings
        };

        return tripRepository.Update(tripEntity);
    }

    public Task Delete(Guid tripId)
    {
        return tripRepository.Delete(tripId);
    }
}
