using System.Net.Http.Headers;

namespace RecipeRevolutionBlazor.Services.Users
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
            var token = _authTokenService.Token;
            if (!string.IsNullOrEmpty(token))
            {
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }

            return await base.SendAsync(request, cancellationToken);
        }
    }
}
