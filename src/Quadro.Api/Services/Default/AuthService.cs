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

        public async Task<UserSignInResult> SignIn(string email, string password)
        {
            clientProvider.BearerToken = null;
            var url = $"Authorization/SignIn?email={email}&password={password}";
            var client = clientProvider.GetClient();
            var response = await client.GetAsync(url);
            var result = await jsonFunctions.ReadFromJsonAsync<UserSignInResult>(response);
            clientProvider.BearerToken = result.Bearer;
            clientProvider.RefreshToken = result.RefreshToken;
            return result;
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

        public async Task<NewBusinessAccountResult> CreateBusinessAccount(BusinessAccountInfo accountInfo)
        {
            var url = $"Authorization/CreateBusinessAccount";
            var client = clientProvider.GetClient();
            var response = await client.PutAsJsonAsync(url, accountInfo);
            return await jsonFunctions.ReadFromJsonAsync<NewBusinessAccountResult>(response);
        }


        public async Task<BusinessAccountInfo> ReadBusinessAccountInfo()
        {
            string url = $"Authorization/ReadBusinessAccountInfo";
            var client = clientProvider.GetClient();
            HttpResponseMessage response = await client.GetAsync(url);
            return await jsonFunctions.ReadFromJsonAsync<BusinessAccountInfo>(response);
        }

        public async Task<BusinessAccountInfo> UpdateBusinessAccountInfo(BusinessAccountInfo accountInfo)
        {
            var url = $"Authorization/UpdateBusinessAccountInfo";
            var client = clientProvider.GetClient();
            var response = await client.PutAsJsonAsync(url, accountInfo);
            return await jsonFunctions.ReadFromJsonAsync<BusinessAccountInfo>(response);
        }

        public async Task<DeleteBusinessAccountResult> DeleteBusinessAccount()
        {
            string url = $"Authorization/DeleteBusinessAccount";
            var client = clientProvider.GetClient();
            HttpResponseMessage response = await client.GetAsync(url);
            return await jsonFunctions.ReadFromJsonAsync<DeleteBusinessAccountResult>(response);
        }

        public async Task<UserAccountInfo> CreateUserAccount(NewUserAccountInfo accountInfo)
        {
            var url = $"Authorization/CreateUserAccount";
            var client = clientProvider.GetClient();
            var response = await client.PutAsJsonAsync(url, accountInfo);
            return await jsonFunctions.ReadFromJsonAsync<UserAccountInfo>(response);
        }


        public async Task<IEnumerable<UserAccountInfo>> ReadUserAccounts()
        {
            string url = $"Authorization/ReadUserAccounts";
            var client = clientProvider.GetClient();
            HttpResponseMessage response = await client.GetAsync(url);
            return await jsonFunctions.ReadFromJsonAsync<IEnumerable<UserAccountInfo>>(response);
        }

        public async Task<UserAccountInfo> UpdateUserAccount(UserAccountInfo accountInfo)
        {
            var url = $"Authorization/UpdateUserAccount";
            var client = clientProvider.GetClient();
            var response = await client.PutAsJsonAsync(url, accountInfo);
            return await jsonFunctions.ReadFromJsonAsync<UserAccountInfo>(response);
        }


        public async Task<DeleteUserAccountResult> DeleteUserAccount(string email)
        {
            string url = $"Authorization/DeleteUserAccount?email={email}";
            var client = clientProvider.GetClient();
            HttpResponseMessage response = await client.GetAsync(url);
            return await jsonFunctions.ReadFromJsonAsync<DeleteUserAccountResult>(response);
        }


        public async Task<ChangePasswordResult> ResetPassword(string oldpassword, string newpassword)
        {
            var url = $"Authorization/ChangePassword?oldpassword={oldpassword}&newpassword={newpassword}";
            var client = clientProvider.GetClient();
            var response = await client.GetAsync(url);
            var result = await jsonFunctions.ReadFromJsonAsync<ChangePasswordResult>(response);
            return result;
        }
    }
}
