

using BusinessLayer.Dtos.Admin;
using DataLayer.Entities;
using System.Collections.Generic;

namespace BusinessLayer.Services.InterFace
{
    public interface IAdminUser
    {
        List<UserListViewModel> GetAllUser();
    }
}
