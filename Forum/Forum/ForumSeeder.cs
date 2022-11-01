using Forum.Entities;
using Microsoft.EntityFrameworkCore;

namespace Forum
{
    public class ForumSeeder
    {
        private readonly ForumDbContext _context;

        public ForumSeeder(ForumDbContext context)
        {
            _context = context;
        }

        public async void Seed()
        {
            if (_context.Database.CanConnect())
            {
                var pendingMigrations = _context.Database.GetPendingMigrations();

                if (pendingMigrations != null && pendingMigrations.Any())
                {
                    _context.Database.Migrate();
                }
                if(!_context.Roles.Any())
                {
                    var roles = GetRoles();
                    await _context.Roles.AddRangeAsync(roles);
                    await _context.SaveChangesAsync();
                }


                if (!_context.Users.Any())
                {
                    var users = GetUsers();
                    await _context.Users.AddRangeAsync(users);
                    await _context.SaveChangesAsync();
                }
            }
        }

        public IEnumerable<Role> GetRoles()
        {
            var roles = new List<Role>()
            {
                new Role()
                {
                    Name = "User"
                },
                new Role()
                {
                    Name = "Admin"
                }
            };
            return roles;
        }
        public IEnumerable<User> GetUsers()
        {
            var users = new List<User>()
            {
                new User()
                {
                    UserName = "john1997",
                    PasswordHash = "AQAAAAEAACcQAAAAEJgxNorzKzcpDi90JSCKGbqloXVb31ts+zm3VD+ajhl0Y4I011sLS2fUNEYMhJqt8g==", //password = 123456
                    RoleId = 1
                },
                new User()
                {
                    UserName = "admin4326",
                    PasswordHash = "AQAAAAEAACcQAAAAEJgxNorzKzcpDi90JSCKGbqloXVb31ts+zm3VD+ajhl0Y4I011sLS2fUNEYMhJqt8g==", //password = 123456
                    RoleId = 2
                }
            };
            return users;
        }
    }
}
