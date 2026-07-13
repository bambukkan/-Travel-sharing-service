public interface IUserRepository
{
    Task<List<UserEntity>> GetAll();
    Task<UserEntity?> GetById(Guid userId);
    Task<UserEntity?> GetByEmail(string email);
    Task<List<UserEntity>> GetByTripId(Guid tripId);
    Task Add(UserEntity user);
    Task Update(UserEntity user);
    Task Delete(Guid userId);
}

