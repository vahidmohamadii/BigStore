
using BusinessLayer.Convertor;
using BusinessLayer.Dtos.Account;
using BusinessLayer.Services.InterFace;
using BusinessLayer.Utility;
using DataLayer.Context;
using DataLayer.Entities;
using Microsoft.EntityFrameworkCore.Internal;
using System;
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
    }
}
