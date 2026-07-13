public interface IUserService
{
    Task<List<UserEntity>> GetAll();
    Task<UserEntity?> GetById(Guid userId);
    Task<UserEntity?> GetByEmail(string email);
    Task<List<UserEntity>> GetByTripId(Guid tripId);
    Task Add(Guid id, string name, string email, string password);
    Task Update(Guid id, string name, string email, string password);
    Task Delete(Guid userId);
}
