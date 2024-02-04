using AutoMapper;
using RecipeRevolution.Domain.Entities;
using RecipeRevolution.Domain.Models;
using RecipeRevolution.Models;

namespace RecipeRevolution.Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Recipe, RecipeDto>();
            CreateMap<CreateRecipeDto, Recipe>();
            CreateMap<Recipe, MyRecipeDto>();
            CreateMap<Category, CategoryDto>();
            CreateMap<Image, ImageDto>();
            CreateMap<ImageDto, Image>();
            CreateMap<Recipe,RecipeWithPhotoDto>().ForMember(dto => dto.Data, conf => conf.MapFrom(r => r.Images.FirstOrDefault().Data)); ;
            CreateMap<User,UpdateUserDto>();
            CreateMap<Recipe,NameAndIMGRecipeDto>();
        }
    }
}
