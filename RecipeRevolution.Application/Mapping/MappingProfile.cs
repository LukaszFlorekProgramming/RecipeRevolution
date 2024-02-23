using AutoMapper;
using RecipeRevolution.Domain.Entities;
using RecipeRevolution.Domain.Models;
using RecipeRevolution.Domain.Models.Category;
using RecipeRevolution.Domain.Models.Comment;
using RecipeRevolution.Domain.Models.Image;
using RecipeRevolution.Domain.Models.Recipe;
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
            CreateMap<Recipe,RecipeWithPhotoDto>()
                    .ForMember(dto => dto.Data, conf => conf.MapFrom(r => r.Images.FirstOrDefault().Data));
            CreateMap<User,UpdateUserDto>();
            CreateMap<Recipe,NameAndIMGRecipeDto>();
            CreateMap<Comment,CommentDto>();
            CreateMap<CreateCommentDto, Comment>();
            CreateMap<DisplayCommentDto, Comment>();
            CreateMap<Comment, CommentUserDto>()
                    .ForMember(dest => dest.RecipeName, opt => opt.MapFrom(src => src.Recipe.Name));

        }
    }
}
