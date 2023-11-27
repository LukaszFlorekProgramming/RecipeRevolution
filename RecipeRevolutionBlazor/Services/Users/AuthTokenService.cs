namespace RecipeRevolutionBlazor.Services.Users
{
    public class AuthTokenService
    {
        public string Token { get; private set; }

        public void SetToken(string token)
        {
            Token = token;
        }
    }
}
