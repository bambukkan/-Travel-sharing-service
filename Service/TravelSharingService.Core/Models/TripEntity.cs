public class TripEntity
{
    public Guid Id {get;set;}
    public string Name {get;set;} = string.Empty;
    public DateTime StartTime {get;set;}
    public DateTime EndTime {get;set;}
    public List<TripLocation> TripLocations {get;set;} = new();
    public List<TripParticipantEntity> Participants { get; set; } = new();
    public decimal OverallBudget {get;set;}
    public List<SpendingEntity> Spendings { get; set; } = new();

    // В поездке должны быть траты, а в тратах показывается кто кому должен
    // И это будет по итогу суммироваться с трат,
}

public class TripLocation
{
    public Guid Id { get; set; }
    public Guid TripId { get; set; }
    public TripEntity Trip { get; set; } = null!;
    public string Country {get;set;} = string.Empty;
    public string City {get;set;} = string.Empty;
    public DateTime StartDate {get;set;}
    public DateTime EndDate {get;set;}
    public string Currency {get;set;} = string.Empty;

}

public class TripParticipantEntity
{
    public Guid Id { get; set; }

    public Guid TripId { get; set; }
    public TripEntity? Trip { get; set; }

    public Guid UserId { get; set; }
    public UserEntity? User { get; set; }

    public TripRole Role { get; set; }
}

public enum TripRole
{
    Owner,
    Participant
}