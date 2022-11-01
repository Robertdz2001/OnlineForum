using AutoMapper;
using Forum.Entities;
using Forum.Exceptions;
using Forum.Models.PostModels;
using Forum.Models.UserModels;
using Microsoft.EntityFrameworkCore;

namespace Forum.Services
{
    public interface IPostService
    {
        Task<IEnumerable<ShortPostDto>> GetAll();
        Task<int> CreatePost(CreateUpdatePostDto dto);
    }

    public class PostService : IPostService
    {
        private readonly ForumDbContext _context;
        private readonly IMapper _mapper;
        private readonly IUserContextService _userContextService;
        public PostService(ForumDbContext context, IMapper mapper, IUserContextService userContextService)
        {
            _context = context;
            _mapper = mapper;
            _userContextService = userContextService;
        }

        public async Task<IEnumerable<ShortPostDto>> GetAll()
        {
            var posts = await _context.Posts
                .Include(p => p.Category)
                .Include(p => p.User)
                .ToListAsync();

            var shortPostsDtos = _mapper.Map<List<ShortPostDto>>(posts);

            return shortPostsDtos;

        }

        public async Task<int> CreatePost(CreateUpdatePostDto dto)
        {
            if(! await _context.Categories.AnyAsync(c=>c.Id == dto.CategoryId))
            {
                throw new NotFoundException("Category not Found");
            }


            var newPost = new Post()
            {
                Title = dto.Title,
                Content = dto.Content,
                CategoryId = dto.CategoryId,
                AnswerCount = 0,
                ViewCount = 0,
                CreatedOn = DateTime.Now,
                UserId = (int)_userContextService.GetUserId,
            };

            await _context.AddAsync(newPost);
            await _context.SaveChangesAsync();
            return newPost.Id;
        }
    }
}
//public int Id { get; set; }
//public string Title { get; set; }
//public int AnswerCount { get; set; } = 0;
//public int ViewCount { get; set; } = 0;
//public DateTime CreatedOn { get; set; }
//public int CategoryId { get; set; }
//public virtual Category Category { get; set; }
//public int UserId { get; set; }
//public virtual UserDto User { get; set; }