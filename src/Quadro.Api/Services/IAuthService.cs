using Quadro.DataModel.Authorization;

namespace Quadro.Api.Services
{
    public interface IAuthService
    {
        Task<InvitationAcceptationResult> AcceptInvitation(string userId, string companyId, string token);
        Task<UserSignOutResult> SignOut();
        Task<UserRoleInfo> GetUserRoleInfo();

    }
}
