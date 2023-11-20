using RecipeRevolution.Domain.Models;
using RecipeRevolution.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeRevolution.Application.Interfaces
{
    public interface IRecipesService
    {
        IEnumerable<RecipeDto> GetAll();
    }
}
