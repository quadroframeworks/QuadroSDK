using Quadro.DataModel.Authorization;

namespace Quadro.Api.Services
{
    public interface IAuthService
    {
        void SetBearer(string bearer);
        Task<UserSignOutResult> SignOut();
        Task<UserRoleInfo> GetUserRoleInfo();

    }
}
