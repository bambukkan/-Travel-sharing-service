public record CreateSpendingRequest
(
    Guid Id,
    Guid TripId,
    Guid CreatedByUserId,
    SpendingCategory Category,
    string Currency,
    decimal Amount,
    string Name,
    List<SpendingPaymentEntity> Payments,
    List<SpendingShareEntity> Shares
);

public record UpdateSpendingRequest
(
    Guid Id,
    Guid TripId,
    Guid CreatedByUserId,
    SpendingCategory Category,
    string Currency,
    decimal Amount,
    string Name,
    List<SpendingPaymentEntity> Payments,
    List<SpendingShareEntity> Shares
);
