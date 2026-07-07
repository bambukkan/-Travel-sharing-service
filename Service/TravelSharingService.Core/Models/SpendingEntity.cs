// Траты

public class SpendingEntity
{
    public Guid Id {get;set;}

    public Guid TripId { get; set; }
    public TripEntity? Trip { get; set; }
    public Guid CreatedByUserId { get; set; }
    public UserEntity? CreatedByUser { get; set; }
    public SpendingCategory Category {get;set;} 
    public string Currency {get;set;} = string.Empty;
    public decimal Amount { get; set; }
    public string Name { get; set; } = string.Empty;
    // поле фотографии чеков, хз как оно должно быть
    // Надо продумать кто кому сколько должен
    public List<SpendingPaymentEntity> Payments { get; set; } = new();
    public List<SpendingShareEntity> Shares { get; set; } = new();
}


public enum SpendingCategory
{
    Default,
    Custom
}

public class SpendingPaymentEntity
{
    public Guid Id { get; set; }

    public Guid SpendingId { get; set; }
    public SpendingEntity? Spending { get; set;}
    public Guid UserId { get; set; }
    public UserEntity User { get; set; } = null!;
    public decimal AmountPaid { get; set; }
}

public class SpendingShareEntity
{
    public Guid Id { get; set; }

    public Guid SpendingId { get; set; }
    public SpendingEntity Spending { get; set; } = null!;

    public Guid UserId { get; set; }
    public UserEntity User { get; set; } = null!;

    public decimal AmountOwed { get; set; }
}