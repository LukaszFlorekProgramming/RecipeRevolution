using RecipeRevolution.Application.Interfaces;
using System.Security.Claims;

namespace RecipeRevolution.Services
{
    public class UserContextService : IUserContextService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public UserContextService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public ClaimsPrincipal User => _httpContextAccessor.HttpContext?.User;
        public int? GetUserId => (int?)int.Parse(User is null ? null : User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier).Value);
    }
}
