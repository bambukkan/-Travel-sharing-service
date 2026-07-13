public record CreateTripRequest
(
    Guid Id,
    string Name,
    DateTime StartTime,
    DateTime EndTime,
    List<TripLocation> TripLocations,
    List<TripParticipantEntity> Participants,
    decimal OverallBudget
);

public record UpdateTripRequest
(
    Guid Id,
    string Name,
    DateTime StartTime,
    DateTime EndTime,
    List<TripLocation> TripLocations,
    List<TripParticipantEntity> Participants,
    decimal OverallBudget,
    List<SpendingEntity> Spendings
);
