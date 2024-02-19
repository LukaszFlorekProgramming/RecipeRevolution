namespace RecipeRevolutionBlazorApp.Services.Users
{
    public class RegistrationResult
    {
        public bool Success { get; set; }
        public IEnumerable<string> Errors { get; set; } = new List<string>();
    }
}
