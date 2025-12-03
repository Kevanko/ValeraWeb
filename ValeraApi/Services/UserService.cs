using Microsoft.AspNetCore.Identity;
using ValeraApi.Data;
using ValeraApi.Models;

namespace ValeraApi.Services;

public class UserService
{
    private readonly AppDbContext _context;
    private readonly PasswordHasher<User> _passwordHasher = new();

    public UserService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<User?> RegisterAsync(string username, string email, string password)
    {
        if (_context.Users.Any(u => u.Email == email))
            return null;

        var user = new User
        {
            Username = username,
            Email = email,
            PasswordHash = _passwordHasher.HashPassword(null, password),
            Role = "User"
        };

        _context.Users.Add(user);
        await _context.SaveChangesAsync();
        return user;
    }

    public User? Authenticate(string email, string password)
    {
        var user = _context.Users.FirstOrDefault(u => u.Email == email);
        if (user == null) return null;

        var result = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, password);
        return result == PasswordVerificationResult.Success ? user : null;
    }
}