using BusinessLayer.Dtos.Admin;
using DataLayer.Entities;
using System.Collections.Generic;

namespace BusinessLayer.Services.InterFace
{
    public interface IAdminUser
    {
        List<UserListViewModel> GetAllUser();
        List<RoleViewModel> GetRoles();
        int InsertUserAdmin(InsertUserViewModel model);
        User FindUserByUserName(string userName);
    }
}
