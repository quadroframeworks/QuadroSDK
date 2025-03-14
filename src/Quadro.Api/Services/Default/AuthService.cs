using Quadro.DataModel.Authorization;
using System.Net.Http.Json;

namespace Quadro.Api.Services.Default
{
    public class AuthService : IAuthService
    {

        private IHttpClientProvider clientProvider;
        private HttpJsonFunctions jsonFunctions;
        private Timer refreshTimer = null!;
        public AuthService(IHttpClientProvider clientProvider, HttpJsonFunctions jsonFunctions)
        {
            this.clientProvider = clientProvider;
            this.jsonFunctions = jsonFunctions;
            StartRefreshTimer();

        }

        public void StartRefreshTimer()
        {
            refreshTimer = new Timer(async _ =>
            {
                await RefreshToken();
            }, null, TimeSpan.Zero, TimeSpan.FromMinutes(5));
        }

        public void SetBearer(string bearer)
        {
            clientProvider.BearerToken = bearer;
        }

        private async Task RefreshToken()
        {
            if (clientProvider.RefreshToken == null)
                return;

            var url = $"Authorization/RefreshToken?refreshToken={clientProvider.RefreshToken}";
            var client = clientProvider.GetClient();
            var response = await client.GetAsync(url);
            var result = await jsonFunctions.ReadFromJsonAsync<RefreshTokenResult>(response);
            clientProvider.BearerToken = result.Bearer;
            clientProvider.RefreshToken = result.RefreshToken;
        }

        public async Task<UserSignOutResult> SignOut()
        {
            if (clientProvider.BearerToken == null)
                return new UserSignOutResult() { Success = false };

            var url = $"Authorization/SignOut";
            var client = clientProvider.GetClient();
            var response = await client.GetAsync(url);
            var result = await jsonFunctions.ReadFromJsonAsync<UserSignOutResult>(response);

            if (result.Success)
            {
                clientProvider.BearerToken = null;
                clientProvider.RefreshToken = null;
            }
            return result;
        }

        public async Task<UserRoleInfo> GetUserRoleInfo()
        {
            var url = $"Authorization/GetUserRoleInfo";
            var client = clientProvider.GetClient();
            var response = await client.GetAsync(url);
            var result = await jsonFunctions.ReadFromJsonAsync<UserRoleInfo>(response);
            return result;
        }

    }
}
