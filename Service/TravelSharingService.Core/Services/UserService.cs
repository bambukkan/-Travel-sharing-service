public class UserService(IUserRepository userRepository) : IUserService
{
    public Task<List<UserEntity>> GetAll()
    {
        return userRepository.GetAll();
    }

    public Task<UserEntity?> GetById(Guid userId)
    {
        return userRepository.GetById(userId);
    }

    public Task<UserEntity?> GetByEmail(string email)
    {
        return userRepository.GetByEmail(email);
    }

    public Task<List<UserEntity>> GetByTripId(Guid tripId)
    {
        return userRepository.GetByTripId(tripId);
    }

    public Task Add(UserEntity user)
    {
        return userRepository.Add(user);
    }

    public Task Update(UserEntity user)
    {
        return userRepository.Update(user);
    }

    public Task Delete(Guid userId)
    {
        return userRepository.Delete(userId);
    }
}
