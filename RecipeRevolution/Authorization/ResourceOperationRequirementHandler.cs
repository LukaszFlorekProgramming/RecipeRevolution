using Microsoft.AspNetCore.Authorization;
using RecipeRevolution.Domain.Entities;
using System.Security.Claims;

namespace RecipeRevolution.Authorization
{
    public class ResourceOperationRequirementHandler : AuthorizationHandler<ResourceOperationRequirement, Recipe>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, ResourceOperationRequirement requirement, Recipe recipe)
        {
            if(requirement.ResourseOperation == ResourseOperation.Read ||
               requirement.ResourseOperation == ResourseOperation.Create)
            {
                context.Succeed(requirement);
            }

            var userId = context.User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier).Value;
            if(recipe.CreatedById == int.Parse(userId))
            {
                context.Succeed(requirement);
            }
            return Task.CompletedTask;
        }
    }
}
