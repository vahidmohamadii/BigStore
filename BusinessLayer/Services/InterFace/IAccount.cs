

using BusinessLayer.Dtos.Account;
using DataLayer.Entities;

namespace BusinessLayer.Services.InterFace
{
    public interface IAccount
    {
        bool IsUserNameUnique(string userName);
        bool IsEmailUnique(string email);
        int AddUser(RegisterViewModel register);
        User LoginUser(LoginViewModel login);
        void ActiveAccount(string id);
        void ForGotPassword(ForgotViewModel forgot);

        User FindUserByUserName(string userName);
        User FindUserByUserId(int userId);

        ShowUserPanelData GetUserInfoForUserPanel(string userName);
    }
}
