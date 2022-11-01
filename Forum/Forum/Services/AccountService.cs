using Forum.Entities;
using Forum.Models;
using Microsoft.AspNetCore.Identity;

namespace Forum.Services
{
    public interface IAccountService
    {
        Task RegisterUser(RegisterUserDto dto);
    }

    public class AccountService : IAccountService
    {
        private readonly ForumDbContext _context;
        private readonly IPasswordHasher<User> _passwordHasher;

        public AccountService(ForumDbContext context, IPasswordHasher<User> passwordHasher)
        {
            _context = context;
            _passwordHasher = passwordHasher;
        }

        public async Task RegisterUser(RegisterUserDto dto)
        {
            var newUser = new User()
            {
                UserName = dto.UserName,
                RoleId = dto.RoleId,
                
            };
            var hashedPassword = _passwordHasher.HashPassword(newUser, dto.Password);

            newUser.PasswordHash = hashedPassword;
            await _context.Users.AddAsync(newUser);
            await _context.SaveChangesAsync();
        }
    }
}
