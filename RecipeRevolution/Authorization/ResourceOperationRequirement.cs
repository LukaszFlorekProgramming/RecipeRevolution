using Microsoft.AspNetCore.Authorization;
using System.Reflection;

namespace RecipeRevolution.Authorization
{
    public enum ResourseOperation
    {
        Create,
        Read,
        Update,
        Delete,
    }
    public class ResourceOperationRequirement : IAuthorizationRequirement
    {
        public ResourceOperationRequirement(ResourseOperation resourseOperation)
        {
            ResourseOperation = resourseOperation;
        }
        public ResourseOperation ResourseOperation { get; }
    }
}
