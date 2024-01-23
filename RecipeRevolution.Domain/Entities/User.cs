using Microsoft.AspNetCore.Identity;

namespace RecipeRevolution.Domain.Entities
{
    public class User : IdentityUser
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Gender { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? Nationality { get; set; }
    }
}
