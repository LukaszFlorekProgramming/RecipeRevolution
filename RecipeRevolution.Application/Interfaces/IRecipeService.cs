﻿using RecipeRevolution.Domain.Models;
using RecipeRevolution.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace RecipeRevolution.Application.Interfaces
{
    public interface IRecipeService
    {
        RecipeDto GetById(int id);
        PagedResult<RecipeDto> GetAll(RecipeQuery query);
        public PagedResult<RecipeWithPhotoDto> GetAllWithPhoto(RecipeQuery query);
        IEnumerable<MyRecipeDto> GetUserRecipes(int id);
        IEnumerable<RecipeWithPhotoDto> GetRecipesByCategory(string name);
        IEnumerable<CategoryDto> GetAllCategory();
        int Create(CreateRecipeDto recipeDto);
        bool Delete(int id);
        bool Update(UpdateRecipeDto recipeDto, int id);

    }
}
