
using BusinessLayer.Convertor;
using BusinessLayer.Dtos.Account;
using BusinessLayer.Dtos.Wallet;
using BusinessLayer.Services.InterFace;
using BusinessLayer.Utility;
using DataLayer.Context;
using DataLayer.Entities;
using DataLayer.Entities.Wallet;
using DataLayer.Migrations;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace BusinessLayer.Services.Account
{

    public class Account : IAccount
    {
        private readonly BigStoreContext _context;
        public Account(BigStoreContext context)
        {
            _context = context;
        }

        public bool IsEmailUnique(string email)
        {
           return _context.users.Where(x => x.Email == Trim.EmailTrim(email)).Any();
        }

        public bool IsUserNameUnique(string userName)
        {
            return _context.users.Where(x => x.UserName == userName).Any();

        }
        public int AddUser(RegisterViewModel register)
        {
       
            User user = new User()
            {
                Email = register.Email,
                UserName = register.UserName,
                Password = register.Password,
                RegisterDate = DateTime.Now,
                IsActive = false,
                UserAvatar = "",
                ActiveCode = GenerateActiveCode.GenerateActiveCodes()

            };
            _context.users.Add(user);
            _context.SaveChanges();

            return user.UserId;
        }

        public User LoginUser(LoginViewModel login)
        {
            var user = _context.users.Where(x => x.UserName == login.UserName && x.Password == login.Password).SingleOrDefault();
            if (user != null) 
            {
                return user;
            }
            else
                return null;

        }

        public void ActiveAccount(string id)
        {
           var user= _context.users.Where(x => x.ActiveCode == id).SingleOrDefault();
            if (user != null) 
            {
                user.IsActive = true;
                user.ActiveCode= GenerateActiveCode.GenerateActiveCodes();
                _context.SaveChanges();
            }
        }

        public void ForGotPassword(ForgotViewModel forgot)
        {
            throw new NotImplementedException();
        }

        public User FindUserByUserName(string userName)
        {
            return _context.users.Where(x => x.UserName == userName).FirstOrDefault();
        }

        public User FindUserByUserId(int userId)
        {
            return _context.users.Where(x => x.UserId == userId).FirstOrDefault();
        }

        public ShowUserPanelData GetUserInfoForUserPanel(string userName)
        {
            var userId = FindUserByUserName(userName).UserId;
            return _context.users.Where(x => x.UserName == userName).Select(c => new ShowUserPanelData() { 
            
            Email= c.Email,
            UserName= c.UserName,
            RegisterDate =MiladyToShamsi.ToShamsi(c.RegisterDate),
            Wallet=BalanceUserWallet(userId),
            ImageName=c.UserAvatar
            
            }).Single();
        }

        public void EditUserInfoForUserPanel(string userName, EditUserPanelData editUserPanel)
        {
            var user = FindUserByUserName(userName);

            if(editUserPanel.ProfilePic != null)
            {
                var IMAGEPATH = "";
                if (editUserPanel.ProfilePic.FileName != "avatar.jpg")
                {

                    IMAGEPATH = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/UserAvatar", editUserPanel.ImageName);
                    if (File.Exists(IMAGEPATH))
                    {
                        File.Delete(IMAGEPATH);
                    }
                    editUserPanel.ImageName = GenerateActiveCode.GenerateActiveCodes() + Path.GetExtension(editUserPanel.ProfilePic.FileName);
                    IMAGEPATH = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/UserAvatar", editUserPanel.ImageName);

                    using (var stream = new FileStream(IMAGEPATH, FileMode.Create))
                    {
                        editUserPanel.ProfilePic.CopyTo(stream);
                    }
                }
            }

       

            user.Email = editUserPanel.Email;
            user.UserAvatar = editUserPanel.ImageName;
            _context.users.Update(user);
            _context.SaveChanges();


        }

        public void ChangePass(ChangePassViewModel changePass)
        {
            var user = FindUserByUserName(changePass.UserName);

            user.Password = changePass.NewPassword;
            _context.users.Update(user);
            _context.SaveChanges();

        }


        #region Wallet
        public double BalanceUserWallet(int userId)
        {
           var user = FindUserByUserId(userId);
           var debtor = _context.wallets.Where(x => x.UserId == userId && x.WalletTypeId == 1 && x.IsPay).Select(x=>x.Amount).ToList();
           var creditor = _context.wallets.Where(x => x.UserId == userId && x.WalletTypeId == 2 && x.IsPay).Select(x=>x.Amount).ToList();

           var res = creditor.Sum() - debtor.Sum();

            return res;
        }

        public List<UserWalletListViewModel> GetUserWalletList(string userName)
        {
            var user=FindUserByUserName(userName);

            return _context.wallets.Where(x=>x.UserId==user.UserId && x.IsPay).Select(w=>new UserWalletListViewModel() {
            
            Description= w.Description,
            Amount= w.Amount,
            CreateDate= w.CreateDate,   
            WalletTypeId= w.WalletTypeId
            }).ToList();
        }

        public List<UserWalletListViewModel> ShargeWallet(ChargeWalletViewModel charge)
        {
            DataLayer.Entities.Wallet.Wallet wallet = new DataLayer.Entities.Wallet.Wallet();
            var userId = FindUserByUserName(charge.UserName).UserId;
            wallet.UserId = userId;
            wallet.Amount = charge.Amount;
            wallet.CreateDate = DateTime.Now;
            wallet.WalletTypeId = 1;
            wallet.Description = charge.Description;
            _context.wallets.Add(wallet);
            _context.SaveChanges();

            return GetUserWalletList(charge.UserName);
            

        }
        #endregion

    }
}
