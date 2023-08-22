using BusinessLayer.Dtos.Admin;
using BusinessLayer.Services.InterFace;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace BigStore.Pages.Admin.Users
{
    public class InsertUserModel : PageModel
    {
        private readonly IAdminUser _user;
        [BindProperty]
        public InsertUserViewModel InsertUserViewModel { get; set; }
        public InsertUserModel(IAdminUser user)
        {
            _user = user;

        }


        public void OnGet()
        {
            ViewData["Roles"] = _user.GetRoles();
        }

        public void OnPost(List<RoleViewModel> RoleList)
        {
            _user.InsertUserAdmin(InsertUserViewModel);
        }
    }
}
