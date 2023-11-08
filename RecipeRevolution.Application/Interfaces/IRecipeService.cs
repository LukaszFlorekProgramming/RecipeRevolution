using RecipeRevolution.Domain.Models;
using RecipeRevolution.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeRevolution.Application.Interfaces
{
    public interface IRecipeService
    {
        RecipeDto GetById(int id);
        public IEnumerable<RecipeDto> GetAll();
        public int Create(CreateRecipeDto recipeDto);
        public bool Delete(int id);
        public bool Update(UpdateRecipeDto recipeDto, int id);

    }
}
