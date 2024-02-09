using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace RecipeRevolutionBlazor.Services.Users
{
    public class AuthTokenService
    {
        public string Token { get; private set; }
        public event Action OnTokenChanged;

        public void SetToken(string token)
        {
            Token = token;
            OnTokenChanged?.Invoke();
        }
        public void RemoveToken()
        {
            Token = null;
            OnTokenChanged?.Invoke();
        }

        public string GetUserNameFromToken()
        {
            if (string.IsNullOrEmpty(Token))
            {
                return null;
            }

            var handler = new JwtSecurityTokenHandler();
            var jsonToken = handler.ReadToken(Token) as JwtSecurityToken;

            var nameClaim = jsonToken.Claims.FirstOrDefault(claim => claim.Type == ClaimTypes.Name);
            var userName = nameClaim?.Value;

            return userName;
        }
    }
}
