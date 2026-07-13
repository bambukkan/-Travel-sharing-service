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

    public Task Add(Guid id, string name, string email, string password)
    {
        var userEntity = new UserEntity
        {
            Id = id,
            Name = name,
            Email = email,
            PasswordHash = password
        };

        return userRepository.Add(userEntity);
    }

    public Task Update(Guid id, string name, string email, string password)
    {
        var userEntity = new UserEntity
        {
            Id = id,
            Name = name,
            Email = email,
            PasswordHash = password
        };

        return userRepository.Update(userEntity);
    }

    public Task Delete(Guid userId)
    {
        return userRepository.Delete(userId);
    }
}
