using Application.Comments;
using Application.DTOs;
using AutoMapper;
using Domain;

namespace Application.Core
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Post,Post>();
            CreateMap<Category, DTOs.CategoryDto>();
            CreateMap<Review,ReviewDto>();
            CreateMap<AppUser,MentorsearchDto>();
            CreateMap<AppUserCategory,MentorDisplayDto>()
                .ForMember(d => d.DisplayName, o => o.MapFrom(s => s.AppUser.DisplayName))
                .ForMember(d => d.Bio, o => o.MapFrom(s => s.AppUser.Bio));
            CreateMap<Comment,CommentDto>()
                .ForMember(d => d.DisplayName, o => o.MapFrom(s => s.Author.DisplayName))
                .ForMember(d => d.Username, o => o.MapFrom(s => s.Author.UserName))
                .ForMember(d => d.Image, o => o.MapFrom(s => s.Author.ProfilePicture));
            CreateMap<AppUser,UserDto>();
            CreateMap<Skill,SkillDto>();
            CreateMap<AppUserSkill,SkillDto>();
            CreateMap<Skill,CategorySkill>()
                .ForMember(cs=>cs.SkillId,o =>o.MapFrom(s => s.Id));
            CreateMap<AppUser, MentorDisplayDto>();
            CreateMap<AppUserCategory, DTOs.CategoryDto>()
                .ForMember(cd => cd.Id, o => o.MapFrom(auc => auc.CategoryId))
                .ForMember(cd => cd.Name, o=> o.MapFrom(auc => auc.Category.Name));
            CreateMap<Category, CategoryWithSkillsDto>();
            CreateMap<CategorySkill, SkillDto>()
                .ForMember(s => s.Id, o => o.MapFrom(cs => cs.SkillId))
                .ForMember(s => s.Name, o => o.MapFrom(cs => cs.Skill.Name));
        }
    }
}