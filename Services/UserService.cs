using Microsoft.EntityFrameworkCore;
using SecretHitler.Models;

namespace SecretHitler.Services;
public class UserService
{
    public readonly SHContext _dbContext;

    public UserService(SHContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task AddUser(User user)
    {
        await _dbContext.Users.AddAsync(user);
        await _dbContext.SaveChangesAsync();
    }

    public List<User> GetAllUser(string name)
    {
        return _dbContext.Users.ToList();
    }
}