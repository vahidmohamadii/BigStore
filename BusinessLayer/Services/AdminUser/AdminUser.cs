

using BusinessLayer.Dtos.Admin;
using BusinessLayer.Services.InterFace;
using DataLayer.Context;
using DataLayer.Entities;
using System.Collections.Generic;
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
    }
}
