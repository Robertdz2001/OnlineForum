using AutoMapper;
using Forum.Entities;
using Forum.Models.PostModels;

namespace Forum
{
    public class ForumMappingProfile : Profile
    {
        public ForumMappingProfile()
        {
            CreateMap<Post, ShortPostDto>()
                .ForMember(m => m.CategoryName, c => c.MapFrom(s => s.Category.Name))
                .ForMember(m => m.UserName, c => c.MapFrom(s => s.User.UserName));

        }
    }
}
