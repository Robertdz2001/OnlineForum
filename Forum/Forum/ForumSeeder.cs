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
                if (!_context.Categories.Any())
                {
                    var categories = GetCategories();
                    await _context.Categories.AddRangeAsync(categories);
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

        public IEnumerable<Category> GetCategories()
        {
            var categories = new List<Category>()
            {
                new Category()
                {
                    Name = "Games"
                },
                new Category()
                {
                    Name = "Coding"
                },
                new Category()
                {
                    Name = "Politics"
                },
                new Category()
                {
                    Name = "Other"
                },
            };
            return categories;
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
                    RoleId = 1,
                    Posts = new List<Post>()
                    {
                        new Post()
                        {
                            Title="Example Title",
                            Content="Example Content",
                            AnswerCount=1,
                            ViewCount=42,
                            CreatedOn = DateTime.Now,
                            CategoryId = 4,
                            Answers = new List<Answer>()
                            {
                                new Answer()
                                {
                                    Content = "Example Post Answer Content",
                                    CreatedOn = DateTime.Now,
                                    UserId = 2,
                                    Comments = new List<Comment>()
                                    {
                                        new Comment()
                                        {
                                        UserId=1,
                                        Content = "Example Answer Comment1 Content",
                                        CreatedOn = DateTime.Now,
                                        },
                                        new Comment()
                                        {
                                        UserId=2,
                                        Content = "Example Answer Comment2 Content",
                                        CreatedOn = DateTime.Now,
                                        }
                                    }

                                }
                            }

                        }
                    }
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
