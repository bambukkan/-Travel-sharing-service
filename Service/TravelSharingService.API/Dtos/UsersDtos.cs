public record CreateUserRequest
(
    Guid Id,
    string Name,
    string Email,
    string Password
);

public record UpdateUserRequest
(
    Guid Id,
    string Name,
    string Email,
    string Password
);
