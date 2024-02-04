namespace RecipeRevolutionBlazorApp.Models.User
{
    public class ConfirmResetPasswordDto
    {
        public string Email { get; set; }
        public string ResetCode { get; set; }
        public string NewPassword { get; set; }
    }
}
