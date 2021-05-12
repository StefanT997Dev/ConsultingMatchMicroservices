using Application.Categories;
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
            CreateMap<Category,CategoryDto>();
            CreateMap<Review,ReviewDto>();
            CreateMap<AppUser,ConsultantSearchDto>();
            CreateMap<AppUserCategory,Profiles.Profile>()
                .ForMember(d => d.DisplayName, o => o.MapFrom(s => s.AppUser.DisplayName))
                .ForMember(d => d.Bio, o => o.MapFrom(s => s.AppUser.Bio));
        }
    }
}