

using BusinessLayer.Dtos.Account;
using BusinessLayer.Dtos.Wallet;
using DataLayer.Entities;
using DataLayer.Entities.Wallet;
using System.Collections.Generic;

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
        void ChangePass(ChangePassViewModel changePass);
        User FindUserByUserName(string userName);
        User FindUserByUserId(int userId);

        ShowUserPanelData GetUserInfoForUserPanel(string userName);
        void EditUserInfoForUserPanel(string userName, EditUserPanelData editUserPanel);


        #region
        double BalanceUserWallet(int userId);
        List<UserWalletListViewModel> GetUserWalletList(string userName);
        List<UserWalletListViewModel> ShargeWallet(ChargeWalletViewModel charge);


        #endregion
    }
}
