using BusinessLayer.Dtos.Admin;
using BusinessLayer.Services.InterFace;
using BusinessLayer.Utility;
using DataLayer.Context;
using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace BusinessLayer.Services.Wallet
{
    public class AdminUser : IAdminUser
    {
        private readonly BigStoreContext _context;
        public AdminUser(BigStoreContext context)
        {
            _context=context;
        }

        public User FindUserByUserName(string userName)
        {
            return _context.users.Find(userName);
        }

        public List<UserListViewModel> GetAllUser()
        {
            var res= _context.users.Select(x=> new UserListViewModel()
            {
                Email= x.Email,
                RegisterDate= x.RegisterDate,
                 IsActive= x.IsActive,
                 UserAvatar = x.UserAvatar,
                 UserName= x.UserName,


            }).ToList();

            return res;
        }

        public List<RoleViewModel> GetRoles()
        {
            List<RoleViewModel> roleModelList = new List<RoleViewModel>();
            RoleViewModel roleModel = new RoleViewModel();
           var roles= _context.roles.ToList();

            foreach (var item in roles)
            {
                roleModel.Id = item.RoleId;
                roleModel.Name = item.RoleName;
                roleModel.IsSelected = false;

                roleModelList.Add(roleModel);
               
            }

            return roleModelList;
           
        }

        public int InsertUserAdmin(InsertUserViewModel model)
        {
            User user = new User();
            UserRole userRole=new UserRole();

  

       

            user.Email = model.Email;
            user.RegisterDate = DateTime.Now;
            user.IsActive = model.IsActive;
            user.UserName = model.UserName;

            #region UserAvatar

            if (model.UserAvatar != null)
            {
                var IMAGEPATH = "";
                if (model.UserAvatar.FileName != "avatar.jpg")
                {

                    IMAGEPATH = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/UserAvatar", model.UserImageName);
                    if (File.Exists(IMAGEPATH))
                    {
                        File.Delete(IMAGEPATH);
                    }
                    model.UserImageName = GenerateActiveCode.GenerateActiveCodes() + Path.GetExtension(model.UserAvatar.FileName);
                    IMAGEPATH = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/UserAvatar",model.UserImageName);

                    using (var stream = new FileStream(IMAGEPATH, FileMode.Create))
                    {
                        model.UserAvatar.CopyTo(stream);
                    }
                }
            }


            #endregion


            var insertUser =  _context.users.Add(user);
            _context.SaveChanges();

            var userId = insertUser.Entity.UserId;
     


            foreach (var item in model.RoleList)
            {
                userRole.UserId = userId;
                userRole.RoleId = item.Id;
                _context.userRoles.Add(userRole);
                _context.SaveChanges();
            }

            return userId;

        }
    }
}
