using Quadro.DataModel.Authorization;
using System.Net.Http.Json;

namespace Quadro.Api.Services.Default
{
    public class AuthService : IAuthService
    {

        private IHttpClientProvider clientProvider;
        private HttpJsonFunctions jsonFunctions;

        public AuthService(IHttpClientProvider clientProvider, HttpJsonFunctions jsonFunctions)
        {
            this.clientProvider = clientProvider;
            this.jsonFunctions = jsonFunctions;
        }

        public async Task<InvitationAcceptationResult> AcceptInvitation(string userId, string companyId, string token)
        {
            var url = $"Authorization/AcceptInvitation?userId={userId}&companyId={companyId}&token={token}";
            var client = await clientProvider.GetClient();
            var response = await client.GetAsync(url);
            var result = await jsonFunctions.ReadFromJsonAsync<InvitationAcceptationResult>(response);
            return result;
        }

        public async Task<UserSignOutResult> SignOut()
        {
            var url = $"Authorization/SignOut";
            var client = await clientProvider.GetClient();
            var response = await client.GetAsync(url);
            var result = await jsonFunctions.ReadFromJsonAsync<UserSignOutResult>(response);
            return result;
        }

        public async Task<UserRoleInfo> GetUserRoleInfo()
        {
            var url = $"Authorization/GetUserRoleInfo";
            var client = await clientProvider.GetClient();
            var response = await client.GetAsync(url);
            var result = await jsonFunctions.ReadFromJsonAsync<UserRoleInfo>(response);
            return result;
        }

    }
}
