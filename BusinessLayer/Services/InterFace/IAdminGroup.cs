

using BusinessLayer.Dtos.Group;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace BusinessLayer.Services.InterFace
{
    public interface IAdminGroup
    {
        void AddGroup(AddGroupViewModel addGroupViewModel);
        List<SelectListItem> GroupList();

        List<GroupListViewModel> GetAllGroups();
    
    }
}
