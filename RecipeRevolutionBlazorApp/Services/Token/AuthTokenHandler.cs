using System.Net.Http.Headers;

namespace RecipeRevolutionBlazorApp.Services.Token
{
    public class AuthTokenHandler : DelegatingHandler
    {
        private readonly AuthTokenService _authTokenService;

        public AuthTokenHandler(AuthTokenService authTokenService)
        {
            _authTokenService = authTokenService;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var token = await _authTokenService.GetToken();
            if (!string.IsNullOrEmpty(token))
            {
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token.Trim('"'));
            }

            return await base.SendAsync(request, cancellationToken);
        }
    }
}
